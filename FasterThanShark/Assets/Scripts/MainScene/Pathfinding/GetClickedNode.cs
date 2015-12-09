using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetClickedNode : MonoBehaviour {

	public int PositionX;
	public int PositionY;
	PathfindingManager pathfindingMNG;



	// Use this for initialization
	void Start () {
		pathfindingMNG = GameObject.FindGameObjectWithTag("Manager").GetComponent<PathfindingManager>();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnMouseOver()
	{
		if(Input.GetMouseButton(1))
		{
			if(pathfindingMNG.selectedPlayer != null)
			{
				pathfindingMNG.MovePlayer(PositionX, PositionY);

			}

		}

	}
}
