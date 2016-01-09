using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetClickedNode : MonoBehaviour {

    //public int PositionX;
    //public int PositionY;
    public float zPosition = 0;
    PathfindingManager pathfindingMNG;
    Vector3 CursorPosPixels;
    Vector3 CursorPos;

    Vector3 position;



	// Use this for initialization
	void Start () {
		pathfindingMNG = GameObject.FindGameObjectWithTag("Manager").GetComponent<PathfindingManager>();
        position = new Vector3(transform.position.x, transform.position.y, zPosition);
	
	}
	
	// Update is called once per frame
	void Update () {
        CursorPosPixels = Input.mousePosition;
        CursorPosPixels.z = -1 * Camera.main.transform.position.z;
        CursorPos = Camera.main.ScreenToWorldPoint(CursorPosPixels);

	}


	void OnMouseOver()
	{
		if(Input.GetMouseButton(1))
		{
			if(pathfindingMNG.selectedPlayer != null)
			{
                pathfindingMNG.MovePlayer(position);
            }

		}

	}
}
