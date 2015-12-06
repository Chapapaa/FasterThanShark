using UnityEngine;
using System.Collections;

public class PathfindingManager : MonoBehaviour {

	public GameObject selectedPlayer;


	public void MovePlayer(int posX, int posY)
	{
		if(selectedPlayer != null)
		{
			selectedPlayer.GetComponent<PlayerMovement>().MoveToNode(posX, posY);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
