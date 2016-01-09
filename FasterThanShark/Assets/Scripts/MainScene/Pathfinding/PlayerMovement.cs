using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


    public float mapScale = 2f;
	public float moveSpeed;
    public bool moving = false;
    bool invalidPath = false;
    Vector2 targetNodePos = new Vector2(0,0);
    int numberofCoroutine = 0;
    AstarAI astarAI;

    Vector2 lastPosition = new Vector2(-1,-1);


	private IEnumerator moveCoroutine;
    private IEnumerator movePlayerCoroutine;

    public void MoveToNode(Vector3 targetPos)
	{
		
        StopAllCoroutines() ;
        moveCoroutine = Move (targetPos);
		StartCoroutine(moveCoroutine);
	}

    public IEnumerator Move(Vector3 targetPosition)
    {
        moving = true;      // Permet de savoir si le personnage est en mouvement
        while (transform.position != targetPosition) // Tant que la position du personnage n'est pas égale à la destination finale voulue.
        {
            astarAI.MoveToPosition(targetPosition);
            astarAI.speed = moveSpeed;
            yield return new WaitForSeconds(0.3f);
        }
        
    }


    public void StopMovement()
    {
        StopAllCoroutines();
        moving = false;
        
    }

    // Use this for initialization
    void Start () 
	{
        astarAI = gameObject.GetComponent<AstarAI>();

    }
	
	// Update is called once per frame
	void Update () 
	{

	
	}
}
