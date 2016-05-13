using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class PlayerMovement : MonoBehaviour {

    public bool isAlly = true;
    public float mapScale = 2f;
	public float moveSpeed;
    public bool moving = false;
    AILerp aiLerp;
    ShipMap mapSCR;
    Vector3 tempCellPos = new Vector3();

    ABPath path = null;
    List<PathDest> goalList = new List<PathDest>();



    private IEnumerator moveCoroutine;

    public void MoveToNode(Vector3 targetPos)
	{
        mapSCR.RemoveCharacterPosition(gameObject, isAlly);
        mapSCR.RemoveCharacterPosition(gameObject, isAlly, tempCellPos);
        tempCellPos = targetPos;
        mapSCR.SetCharacterPosition(gameObject, isAlly, tempCellPos);
        StopAllCoroutines() ;
        moveCoroutine = Move (targetPos);
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
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                print("YOLOOOOOOOOOOOOw");
                //transform.position = targetPosition;
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
        //mapSCR.SetCharacterPosition(gameObject, isAlly);

    }

    void AjustPosition()
    {
        mapSCR.RemoveCharacterPosition(gameObject, isAlly);
        mapSCR.RemoveCharacterPosition(gameObject, isAlly, tempCellPos);
        ShipCell emptyCell = mapSCR.IsRoomEmpty(transform.position, isAlly);
        if(emptyCell != null)
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
                mapSCR.SetCharacterPosition(gameObject, isAlly);
            }
            aiLerp.target = gameObject.transform.position;            
        }

        else
        {
            goalList.Clear();
            CalculateAllPath();
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
    void CalculateAllPath()
    {
        foreach(ShipRoom room in mapSCR.shipMap)
        {
            if (AstarPath.active == null) return;
            // As there is not Seeker to keep track of the callbacks, we now need to specify the callback every time again
            var p = ABPath.Construct(transform.position, room.roomPosition, OnPathComplete);
            p.nnConstraint = NNConstraint.None;
            // Start the path, but call AstarPath directly
            // AstarPath.active is the current AstarPath instance in the scene
            AstarPath.StartPath(p);
        }

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

    }
	
	// Update is called once per frame
	void Update () 
	{
	}

    void MagicTp()
    {
        print("MAGICTPPPP ---------------------");
        ShipRoom rdmRoom = mapSCR.GetRandomAllyRoom();
        aiLerp.stop = true;
        gameObject.transform.position = rdmRoom.roomPosition;
        MoveToNode(rdmRoom.roomPosition);
    }

    IEnumerator UrgentPathCorrect()
    {
        yield return new WaitForSeconds(0.4f);
        float mini = 100f;
        PathDest fDest = null;
        foreach(PathDest dest in goalList)
        {
            if(dest.pathDist < mini)
            {
                if(Vector3.Distance(dest.endPoint, mapSCR.GetRoomByPos(transform.position).roomPosition) > 0.1f)
                {
                    mini = dest.pathDist;
                    fDest = dest;
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
}
