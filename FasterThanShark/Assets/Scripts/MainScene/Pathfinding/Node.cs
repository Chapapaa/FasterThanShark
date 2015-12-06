using UnityEngine;
using System.Collections;

public class Node {

	public Node parentNode;
	public bool walkable = false;
	public int gValue = 0;
	public int hValue = 0;
	public int fValue = 0;
	public int posX = 0;
	public int posY = 0; 

	public void _Init(bool _walkable, int _posX, int _posY )
		
	{
		walkable = _walkable;
		posX = _posX;
		posY = _posY;
	}

	public Node()
	{
		walkable = false;
	}
}
