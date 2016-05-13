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
    public void MovePlayer(int roomIndex, int map)
    {
        // récupere une cell vide
        if (selectedPlayer == null)
        {
            return;
        }
        shipMapSCR.RemoveCharacterPosition(selectedPlayer, selectedPlayer.GetComponent<PlayerMovement>().isAlly);
        ShipCell freeCell = GetFreeCellInRoom(roomIndex, map);
        if(freeCell != null)
        {
            Vector3 targetPos = freeCell.position;
            selectedPlayer.GetComponent<PlayerMovement>().MoveToNode(targetPos);
        }
    }

    // useless?
    ShipCell GetFreeCellInRoom(int indexOfRoom, int map)
    {
        if(map == 1)
        {
            foreach (var cell in shipMapSCR.enemyShipMap[indexOfRoom].cells)
            {
                if (cell.crew == null)
                {
                    return cell;
                }
            }
        }
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
