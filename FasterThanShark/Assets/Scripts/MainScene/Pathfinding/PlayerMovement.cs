using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public bool isAlly = true;
    public float mapScale = 2f;
	public float moveSpeed;
    public bool moving = false;
    AILerp aiLerp;
    ShipMap mapSCR;
    Vector3 tempCellPos = new Vector3();



	private IEnumerator moveCoroutine;
    private IEnumerator movePlayerCoroutine;

    public void MoveToNode(Vector3 targetPos)
	{
        mapSCR.RemoveCharacterPosition(gameObject, isAlly);
        mapSCR.RemoveCharacterPosition(gameObject, isAlly, tempCellPos);
        tempCellPos = targetPos;
        mapSCR.SetCharacterPosition(gameObject, isAlly, targetPos);
        StopAllCoroutines() ;
        moveCoroutine = Move (targetPos);
		StartCoroutine(moveCoroutine);
	}

    public IEnumerator Move(Vector3 targetPosition)
    {
        moving = true;      // Permet de savoir si le personnage est en mouvement
        while (transform.position != targetPosition) // Tant que la position du personnage n'est pas égale à la destination finale voulue.
        {
            
            transform.position = new Vector3(transform.position.x, transform.position.y, targetPosition.z);
            aiLerp.target = targetPosition;
            aiLerp.speed = moveSpeed;
            aiLerp.SearchPath();
            //
            //astarAI.MoveToPosition(targetPosition);
            //astarAI.speed = moveSpeed;
            //
            print(transform.position);
            print(targetPosition);
            yield return new WaitForSeconds(0.3f);
            if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
            {
                transform.position = targetPosition;
            }
        }
        StopMovement();
    }


    public void StopMovement()
    {
        StopAllCoroutines();
        moving = false;
        mapSCR.RemoveCharacterPosition(gameObject, isAlly, tempCellPos);
        mapSCR.SetCharacterPosition(gameObject, isAlly);


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
}
