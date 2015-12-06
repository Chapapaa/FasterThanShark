using UnityEngine;
using System.Collections;

public class PlayerSelection : MonoBehaviour {

	PathfindingManager pathfindingMNG;

	// Use this for initialization
	void Start () {
		pathfindingMNG = GameObject.FindGameObjectWithTag("Manager").GetComponent<PathfindingManager>();
	
	}



	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			pathfindingMNG.selectedPlayer = gameObject;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
