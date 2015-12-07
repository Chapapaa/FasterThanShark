using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Pathfinding pathfindingSCR;
	public int playerPositionX = 0;
	public int PlayerPositionY = 0;
	public float moveSpeed;
	public bool moving = false;
	bool activeCoroutine = false;

	private IEnumerator myCoroutine;

	public void MoveToNode(int posX, int posY)
	{
		if(activeCoroutine)
		{
			StopCoroutine(myCoroutine);
			activeCoroutine = false;
		}
		myCoroutine = Move (posX, posY);
		StartCoroutine(myCoroutine);
	}


	IEnumerator Move(int posX, int posY)
	{
		activeCoroutine = true;
		while(playerPositionX != posX || PlayerPositionY != posY)
		{
			Node myNodeToGo = pathfindingSCR.GetNodeToGo(playerPositionX,PlayerPositionY,posX,posY);
			if(myNodeToGo.posX == -1)
			{
				break;
			}
			Vector3 nodeToGoPos = new Vector3((float)myNodeToGo.posX / 2 , (float)myNodeToGo.posY / 2);
			Vector3 startNodePos = new Vector3((float)playerPositionX / 2, (float)PlayerPositionY / 2);
			if(posX != (transform.localPosition.x * 2) && posY != (transform.localPosition.y * 2) )
			{
				nodeToGoPos = new Vector3((float)playerPositionX / 2, (float)PlayerPositionY / 2);
			}
			if(transform.localPosition.x - nodeToGoPos.x == 0 && transform.localPosition.y - nodeToGoPos.y == 0)
			{

				playerPositionX = myNodeToGo.posX;
				PlayerPositionY = myNodeToGo.posY;
			}
			else
			{
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, nodeToGoPos ,moveSpeed / 2);
				transform.localPosition = Vector3.MoveTowards(transform.localPosition, nodeToGoPos ,moveSpeed / 2);
				//transform.localPosition = Vector3.MoveTowards(transform.localPosition, nodeToGoPos ,moveSpeed);
			}
			yield return new WaitForSeconds(0.01f);
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
