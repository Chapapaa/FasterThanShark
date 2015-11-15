using UnityEngine;
using System.Collections;

public class Node {

	public Node upperNode;
	public Node rightNode;
	public Node bottomNode;
	public Node leftNode;
	public Node parentNode;
	public bool walkable = false;
	public int gValue = 0;
	public int hValue = 0;
	public int fValue = 0;
	public int posX = 0;
	public int posY = 0; 
	
	public void _Init(Node _upperNode, Node _rightNode, Node _bottomNode, Node _leftNode, bool _walkable, int _posX, int _posY )
	{
		upperNode = _upperNode;
		rightNode = _rightNode;
		bottomNode = _bottomNode;
		leftNode = _leftNode;
		walkable = _walkable;
		posX = _posX;
		posY = _posY;

	}
	public Node()
	{
		walkable = false;
	}
}
