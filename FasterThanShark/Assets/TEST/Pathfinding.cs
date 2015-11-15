using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinding : MonoBehaviour {

	public Map worldMap;

	public Node startNode = new Node();
	public Node endNode = new Node();
	public Node currentNode = new Node();

	public List<Node> AllNodes = new List<Node>();
	public List<Node> OpenL = new List<Node>();
	public List<Node> CloseL = new List<Node>();

	public List<int> FvalueList = new List<int>();

	bool a = true;

	// Use this for initialization
	void Start () 
	{
		startNode = worldMap.a1;
		endNode = worldMap.e15;
		AllNodes.Add(worldMap.a0);
		AllNodes.Add(worldMap.a1);
		AllNodes.Add(worldMap.a2);
		AllNodes.Add(worldMap.a3);
		AllNodes.Add(worldMap.a4);
		AllNodes.Add(worldMap.a5);
		AllNodes.Add(worldMap.a6);
		AllNodes.Add(worldMap.a7);
		AllNodes.Add(worldMap.a8);
		AllNodes.Add(worldMap.a9);
		AllNodes.Add(worldMap.a10);
		AllNodes.Add(worldMap.a11);
		AllNodes.Add(worldMap.a12);
		AllNodes.Add(worldMap.a13);
		AllNodes.Add(worldMap.a14);
		AllNodes.Add(worldMap.a15);
		AllNodes.Add(worldMap.b1);
		AllNodes.Add(worldMap.b2);
		AllNodes.Add(worldMap.b3);
		AllNodes.Add(worldMap.b4);
		AllNodes.Add(worldMap.b5);
		AllNodes.Add(worldMap.b6);
		AllNodes.Add(worldMap.b7);
		AllNodes.Add(worldMap.b8);
		AllNodes.Add(worldMap.b9);
		AllNodes.Add(worldMap.b10);
		AllNodes.Add(worldMap.b11);
		AllNodes.Add(worldMap.b12);
		AllNodes.Add(worldMap.b13);
		AllNodes.Add(worldMap.b14);
		AllNodes.Add(worldMap.b15);
		AllNodes.Add(worldMap.c1);
		AllNodes.Add(worldMap.c2);
		AllNodes.Add(worldMap.c3);
		AllNodes.Add(worldMap.c4);
		AllNodes.Add(worldMap.c5);
		AllNodes.Add(worldMap.c6);
		AllNodes.Add(worldMap.c7);
		AllNodes.Add(worldMap.c8);
		AllNodes.Add(worldMap.c9);
		AllNodes.Add(worldMap.c10);
		AllNodes.Add(worldMap.c11);
		AllNodes.Add(worldMap.c12);
		AllNodes.Add(worldMap.c13);
		AllNodes.Add(worldMap.c14);
		AllNodes.Add(worldMap.c15);
		AllNodes.Add(worldMap.d1);
		AllNodes.Add(worldMap.d2);
		AllNodes.Add(worldMap.d3);
		AllNodes.Add(worldMap.d4);
		AllNodes.Add(worldMap.d5);
		AllNodes.Add(worldMap.d6);
		AllNodes.Add(worldMap.d7);
		AllNodes.Add(worldMap.d8);
		AllNodes.Add(worldMap.d9);
		AllNodes.Add(worldMap.d10);
		AllNodes.Add(worldMap.d11);
		AllNodes.Add(worldMap.d12);
		AllNodes.Add(worldMap.d13);
		AllNodes.Add(worldMap.d14);
		AllNodes.Add(worldMap.d15);
		AllNodes.Add(worldMap.e1);
		AllNodes.Add(worldMap.e2);
		AllNodes.Add(worldMap.e3);
		AllNodes.Add(worldMap.e4);
		AllNodes.Add(worldMap.e5);
		AllNodes.Add(worldMap.e6);
		AllNodes.Add(worldMap.e7);
		AllNodes.Add(worldMap.e8);
		AllNodes.Add(worldMap.e9);
		AllNodes.Add(worldMap.e10);
		AllNodes.Add(worldMap.e11);
		AllNodes.Add(worldMap.e12);
		AllNodes.Add(worldMap.e13);
		AllNodes.Add(worldMap.e14);
		AllNodes.Add(worldMap.e15);
	}

	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKey(KeyCode.Space))
		{
			print (Time.time);
			if(!startNode.walkable)
			{
				ErrorPathFinding();
				return;
			}
			currentNode = startNode;
			currentNode.parentNode = currentNode;
			OpenL.Add(currentNode);
			foreach (Node x in AllNodes)
			{
				x.hValue = Mathf.Abs(endNode.posX - x.posX) + Mathf.Abs(endNode.posY - x.posY);
			}
			int i = 0;
			while (i < 1000)
			{
				i++;
				CloseL.Add(currentNode);
				if((!CloseL.Contains(currentNode.upperNode)) && (!OpenL.Contains(currentNode.upperNode)) && currentNode.upperNode.walkable)
				{
					OpenL.Add(currentNode.upperNode);

				}
				if((!CloseL.Contains(currentNode.rightNode)) && (!OpenL.Contains(currentNode.rightNode)) && currentNode.rightNode.walkable)
				{
					OpenL.Add(currentNode.rightNode);

				}
				if((!CloseL.Contains(currentNode.bottomNode)) && (!OpenL.Contains(currentNode.bottomNode)) && currentNode.bottomNode.walkable)
				{
					OpenL.Add(currentNode.bottomNode);

				}
				if((!CloseL.Contains(currentNode.leftNode)) && (!OpenL.Contains(currentNode.leftNode)) && currentNode.leftNode.walkable)
				{
					OpenL.Add(currentNode.leftNode);

				}
				if(OpenL.Count == 1)
				{
					ErrorPathFinding();
					break;
				}
				OpenL.Remove(currentNode);
				foreach (Node y in OpenL)
				{
					y.parentNode = currentNode ;
					y.gValue = y.parentNode.gValue + 1;
					y.fValue = y.hValue + y.gValue;
				}
				currentNode = SortNodesByFValue(OpenL);
				if(!currentNode.walkable)
				{
					ErrorPathFinding();
					break;
				}
				if(currentNode.posX == endNode.posX && currentNode.posY == endNode.posY)
				{
					print ("Path Found");
					while (currentNode.posY != startNode.posY || currentNode.posX != startNode.posX )
					{
						currentNode = currentNode.parentNode;
					}
					break;
				}
			}
			print (Time.time);
			a = false;
			print(Time.deltaTime);
		}
	}
	
	Node SortNodesByFValue(List<Node> myListToSort)
	{
		Node minNode = new Node();
		int FValue = 9999;

		foreach( Node myNode in myListToSort )
		{
			if(myNode.fValue <= FValue)
			{
				FValue = myNode.fValue;
				minNode = myNode;
			}
		}
		return minNode;
	}

	void ErrorPathFinding()
	{
		print ("Error : No Path found");
	}











}
