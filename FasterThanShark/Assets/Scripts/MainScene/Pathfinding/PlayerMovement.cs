using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Pathfinding pathfindingSCR;
	public int playerPositionX = 0;
	public int playerPositionY = 0;
    public float mapScale = 2f;
	public float moveSpeed;
    public bool hardMoving = false;
	public bool moving = false;
	bool activeCoroutine = false;
    bool invalidPath = false;
    Vector2 targetNodePos = new Vector2(0,0);
    int numberofCoroutine = 0;

    Vector2 lastPosition = new Vector2(-1,-1);


	private IEnumerator moveCoroutine;
    private IEnumerator movePlayerCoroutine;

    public void MoveToNode(int posX, int posY)
	{
		if(activeCoroutine)
		{
			StopCoroutine(moveCoroutine);
			activeCoroutine = false;
		}
        moveCoroutine = Move (posX, posY);
		StartCoroutine(moveCoroutine);
	}

    public IEnumerator Move(int posX, int posY)
    {
        moving = true;      // Permet de savoir si le personnage est en mouvement
        activeCoroutine = true;     // Permet de savoir si la coroutine est déjà en cours d'execution.
        while ((transform.localPosition.x * mapScale) != posX || (transform.localPosition.y * mapScale) != posY) // Tant que la position du personnage n'est pas égale à la destination finale voulue.
        {
            if (hardMoving || numberofCoroutine > 0)
            {
                yield return new WaitForSeconds(0.01f);
                 continue;
            }
            Node targetNode = pathfindingSCR.GetNodeToGo(playerPositionX, playerPositionY, posX, posY);  // Node le plus proche à atteindre.				
            targetNodePos = new Vector2(targetNode.posX, targetNode.posY);       // Position du Node sur la grille du pathfinding
            Vector3 targetNodePosition = new Vector3(targetNodePos.x / mapScale, targetNodePos.y / mapScale);       // Position du Node dans la scene
            Vector2 playerPos = new Vector2(transform.localPosition.x * mapScale, transform.localPosition.y * mapScale);      // Position du joueur sur la grille du pathfinding

            playerPos.x = transform.localPosition.x * mapScale;
            playerPos.y = transform.localPosition.y * mapScale;
            if (targetNode.posX == -1 && lastPosition.x != -1) // 
            {
                Vector3 lastPositionPos = new Vector3(lastPosition.x / mapScale, lastPosition.y / mapScale);
                lastPositionPos.z = transform.localPosition.z;  // ( permet de garder la position du joueur en Z )
                                                                //transform.localPosition = Vector3.MoveTowards(transform.localPosition, lastPositionPos, moveSpeed); // se déplace vers la case.
                movePlayerCoroutine = movePlayer(lastPositionPos);
                StartCoroutine(movePlayerCoroutine);
                break;
            }
            if (((targetNodePos.x != playerPos.x && targetNodePos.y != playerPos.y)) && lastPosition.x != -1)
            {
                Vector3 lastPositionPos = new Vector3(lastPosition.x / mapScale, lastPosition.y / mapScale); // Récupere la position dans la scene du dernier Node parcouru
                lastPositionPos.z = transform.localPosition.z;	// ( permet de garder la position du joueur en Z )
                movePlayerCoroutine = movePlayer(lastPositionPos);
                StartCoroutine(movePlayerCoroutine);
                
            }
            else if (playerPos != targetNodePos && targetNode.posX != -1)
            {
                targetNodePosition.z = transform.localPosition.z;
                movePlayerCoroutine = movePlayer(targetNodePosition);
                StartCoroutine(movePlayerCoroutine);
                if (Mathf.Abs(transform.localPosition.x - targetNodePosition.x) < 0.001)
                {
                    transform.localPosition = new Vector3(targetNodePosition.x, transform.localPosition.y, transform.localPosition.z);
                }
                if (Mathf.Abs(transform.localPosition.y - targetNodePosition.y) < 0.001)
                {
                    transform.localPosition = new Vector3(transform.localPosition.x, targetNodePosition.y, transform.localPosition.z);
                }
            }
            else
            {
                break;
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    public IEnumerator movePlayer(Vector3 targetPosition)
    {
        hardMoving = true;
        numberofCoroutine++;
        if (numberofCoroutine < 1)
        {
            yield break;
        }
        while(transform.localPosition != targetPosition)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed);
            if (Mathf.Abs(transform.localPosition.x - targetPosition.x) < 0.001)
            {
                transform.localPosition = new Vector3(targetPosition.x, transform.localPosition.y, transform.localPosition.z);
            }
            if (Mathf.Abs(transform.localPosition.y - targetPosition.y) < 0.001)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, targetPosition.y, transform.localPosition.z);
            }
            yield return new WaitForSeconds(0.01f);
        }
        playerPositionX = (int)Mathf.Round(transform.localPosition.x * mapScale);
        playerPositionY = (int)Mathf.Round(transform.localPosition.y * mapScale);
        lastPosition = new Vector2(playerPositionX, playerPositionY);
        hardMoving = false;
        numberofCoroutine--;
        yield return null;
    }

    void StopMovement()
    {
        if(activeCoroutine)
        {
            StopCoroutine(moveCoroutine);
        }
        if (hardMoving)
        {
            StopCoroutine(movePlayerCoroutine);
            hardMoving = false;
        }
    }

    // Use this for initialization
    void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{

	
	}
}
