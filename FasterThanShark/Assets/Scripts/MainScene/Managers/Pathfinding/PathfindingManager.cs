using UnityEngine;
using System.Collections;

public class PathfindingManager : MonoBehaviour {

    public ShipMap shipMapSCR;
    public GameObject selectedPlayer;


	public void MovePlayer(Vector3 position)
	{
		if(selectedPlayer != null)
		{

			selectedPlayer.GetComponent<PlayerMovement>().MoveToNode(position);
		}
	}
    public void MovePlayer(int roomIndex)
    {
        if (selectedPlayer != null)
        {
            ShipCell freeCell = GetFreeCellInRoom(roomIndex);
            if(freeCell == null)
            {
                return;
            }
            Vector3 positionToGo = freeCell.position;

            selectedPlayer.GetComponent<PlayerMovement>().MoveToNode(positionToGo);
        }
    }

    ShipCell GetFreeCellInRoom(int indexOfRoom)
    {
        foreach(var cell in shipMapSCR.shipMap[indexOfRoom].cells)
        {
            if(cell.crew == null)
            {
                return cell;
            }
        }
        return null;
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
