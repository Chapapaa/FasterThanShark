using UnityEngine;
using System.Collections;

public class PathfindingManager : MonoBehaviour {

	public GameObject selectedPlayer;


	public void MovePlayer(Vector3 position)
	{
		if(selectedPlayer != null)
		{
			selectedPlayer.GetComponent<PlayerMovement>().MoveToNode(position);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
