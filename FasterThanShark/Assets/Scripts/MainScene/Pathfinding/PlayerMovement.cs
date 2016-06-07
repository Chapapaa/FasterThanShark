using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class PlayerMovement : MonoBehaviour {

    public bool isAlly;
    public float mapScale = 2f;
	public float moveSpeed;
    public bool moving = false;
    AILerp aiLerp;
    ShipMap mapSCR;
    Vector3 tempCellPos = new Vector3();
    CharacterManager charMng;
    bool pathsCalculated = false;


    ABPath path = null;
    List<PathDest> goalList = new List<PathDest>();



    private IEnumerator moveCoroutine;

    public void MoveToNode(Vector3 targetPos)
	{
        aiLerp.ResetToDefault();
        mapSCR.RemoveCharacterPosition(gameObject, isAlly);
        //mapSCR.RemoveCharacterPosition(gameObject, isAlly, tempCellPos);
        charMng.playerCell = null;
        tempCellPos = targetPos;
        ShipCell cellToGo = mapSCR.SetCharacterPosition(gameObject, isAlly, tempCellPos);
        charMng.playerCell = cellToGo;
        StopAllCoroutines() ;
        if(cellToGo == null)
        {
            moveCoroutine = Move(targetPos);
        }
        else
        {
            moveCoroutine = Move(cellToGo.position);
        }
		StartCoroutine(moveCoroutine);
	}



    IEnumerator Move(Vector3 targetPosition)
    {
        moving = true;      // Permet de savoir si le personnage est en mouvement
        Vector3 lastPos = transform.position;
        while (true) // Tant que la position du personnage n'est pas égale à la destination finale voulue.
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
            aiLerp.target = targetPosition;
            aiLerp.speed = moveSpeed;
            aiLerp.SearchPath();
            aiLerp.stop = false;
            yield return new WaitForSeconds(0.3f);
            if (Vector2.Distance(transform.position, targetPosition) < 0.05f)
            {
                break;
            }
            if(transform.position == lastPos)
            {
                break;
            }
            lastPos = transform.position;
        }
        StopMovement();
    }


    public void StopMovement()
    {
        StopAllCoroutines();
        moving = false;
        AjustPosition();

    }

    void AjustPosition()
    {
        mapSCR.RemoveCharacterPosition(gameObject, isAlly);
        //mapSCR.RemoveCharacterPosition(gameObject, isAlly, tempCellPos);
        charMng.playerCell = null;
        ShipCell emptyCell = mapSCR.IsRoomEmpty(transform.position, isAlly);
        if (emptyCell != null)
        {
            Vector2 mypos = new Vector2(transform.position.x, transform.position.y);
            Vector2 mycellpos = new Vector2(emptyCell.position.x, emptyCell.position.y);
            float distance = Vector2.Distance(mypos, mycellpos);
            if (distance > 0.1f) // <===
            {
                MoveToNode(emptyCell.position);
            }
            else
            {
                charMng.playerCell = mapSCR.SetCharacterPosition(gameObject, isAlly);
            }           
        }

        else
        {
            goalList.Clear();
            StartCoroutine(CalculateAllPath());
            StartCoroutine(UrgentPathCorrect());
        }
    }

    public virtual void OnPathComplete(Path _p)
    {
        ABPath p = _p as ABPath;

        if (p == null) throw new System.Exception("This function only handles ABPaths, do not use special path types");

        // Claim the new path
        // This is used for path pooling
        p.Claim(this);

        // Path couldn't be calculated of some reason.
        // More info in p.errorLog (debug string)
        if (p.error)
        {
            p.Release(this);
            return;
        }
        goalList.Add(new PathDest(p.endPoint, p.GetTotalLength()));

        // Release the previous path
        // This is used for path pooling
        if (path != null) path.Release(this);

        // Replace the old path
        path = p;
    }
    IEnumerator CalculateAllPath()
    {
        pathsCalculated = false;
        if(isAlly)
        {
            foreach (ShipRoom room in mapSCR.shipMap)
            {

                if (AstarPath.active == null) break;
                // As there is not Seeker to keep track of the callbacks, we now need to specify the callback every time again
                var p = ABPath.Construct(transform.position, room.roomPosition, OnPathComplete);
                p.nnConstraint = NNConstraint.None;
                // Start the path, but call AstarPath directly
                // AstarPath.active is the current AstarPath instance in the scene
                AstarPath.StartPath(p);
                yield return StartCoroutine(p.WaitForPath());
            }
        }
        else
        {
            foreach (ShipRoom room in mapSCR.enemyShipMap)
            {

                if (AstarPath.active == null) break;
                // As there is not Seeker to keep track of the callbacks, we now need to specify the callback every time again
                var p = ABPath.Construct(transform.position, room.roomPosition, OnPathComplete);
                p.nnConstraint = NNConstraint.None;
                // Start the path, but call AstarPath directly
                // AstarPath.active is the current AstarPath instance in the scene
                AstarPath.StartPath(p);
                yield return StartCoroutine(p.WaitForPath());
            }
        }
        pathsCalculated = true;
        //There must be an AstarPath instance in the scene

    }

    class PathDest
    {
        public Vector3 endPoint;
        public float pathDist;
        public PathDest(Vector3 _endPoint, float _pathDist)
        {
            endPoint = _endPoint;
            pathDist = _pathDist;
        }
    }


    // Use this for initialization
    void Start () 
	{
        mapSCR = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        aiLerp = gameObject.GetComponent<AILerp>();
        charMng = gameObject.GetComponent<CharacterManager>();
        isAlly = charMng.isAlly;

        StartCoroutine(Initialization());

    }
	
	// Update is called once per frame
	void Update () 
	{
	}

    void MagicTp()
    {
        aiLerp.ResetToDefault();
        ShipRoom rdmRoom = null;
        if (isAlly)
        {
            rdmRoom = mapSCR.GetRandomAllyRoom();
        }
        else
        {
            rdmRoom = mapSCR.GetRandomEnnemyRoom();
        }
        gameObject.transform.position = rdmRoom.roomPosition;
        MoveToNode(rdmRoom.roomPosition);
    }

    IEnumerator UrgentPathCorrect()
    {
        while(!pathsCalculated)
        {
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.1f);
        float mini = 100f;
        PathDest fDest = null;
        foreach(PathDest dest in goalList)
        {
            if (mapSCR.IsRoomEmpty(dest.endPoint, isAlly) != null)
            {
                if (dest.pathDist < mini)
                {
                    if (Vector3.Distance(dest.endPoint, mapSCR.GetRoomByPos(transform.position).roomPosition) > 0.1f)
                    {
                        mini = dest.pathDist;
                        fDest = dest;
                    }
                }
            }
        }
        if(fDest != null)
        {
            MoveToNode(fDest.endPoint);
        }
        else
        {
            MagicTp();
        }
    }
    IEnumerator Initialization()
    {
        yield return new WaitForSeconds(Random.Range(0.02f, 0.1f));
        MoveToNode(mapSCR.GetRoomByPos(transform.position).roomPosition);
    }
}
