using UnityEngine;
using System.Collections;

public class PlayerMvt : MonoBehaviour {

	// OBSOLETE PLEASE REWRITE THIS SCRIPT

	public Map01 worldMap1;
	public Pathfinding2 pathFindingSCR;
	public float distanceBetweenNodes = 0.2f;
	Node startNode;
	Node endNode;
	bool a = true;


	/*
	 * récupere la position de la case a atteindre
	 * récupere la position actuelle
	 * définit la direction a appliquer
	 * 
	 * Si case en haut; moveTop
	 * si case bas : moveBot;
	 * sicase gauche moveLeft
	 * si case droite : moveRight;
	 * 
	 */

	// Use this for initialization
	void Start () 
	{
		startNode = worldMap1.a1;
		endNode = worldMap1.e5;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Space) && a)
		{
			a = false;
		}
		if(Input.GetKey(KeyCode.N))
		{
			a = true;
		}

	}
	void Move()
	{
		Node nodeToGo =  worldMap1.a0;
		if(nodeToGo == worldMap1.a0){return;}
		if(nodeToGo.posX > startNode.posX)
		{
			transform.position = new Vector3(transform.position.x + distanceBetweenNodes, transform.position.y, transform.position.z);
		}
		if(nodeToGo.posX < startNode.posX)
		{
			transform.position = new Vector3(transform.position.x - distanceBetweenNodes, transform.position.y, transform.position.z);
		}
		if(nodeToGo.posY > startNode.posY)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + distanceBetweenNodes, transform.position.z);
		}
		if(nodeToGo.posY < startNode.posY)
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - distanceBetweenNodes, transform.position.z);
		}
		startNode = nodeToGo;
		//transform.position = new Vector3(transform.position.x + distanceBetweenNodes, transform.position.y, transform.position.z);
	}




}
