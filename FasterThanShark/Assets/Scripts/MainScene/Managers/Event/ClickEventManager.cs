using UnityEngine;
using System.Collections;

public class ClickEventManager : MonoBehaviour {

    ShipMap shipMapSCR;
    public PathfindingManager pathMNG;
    float clickCD = 0.3f;

	// Use this for initialization
	void Start () {
        shipMapSCR = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();

    }
	
	// Update is called once per frame
	void Update () {
        if(clickCD >= 0f)
        {
            clickCD -= Time.deltaTime;
        }


    }

    public void ClickOnRoom(int index, int buttonIndex)
    {
        // A revoir , les appelation publiques, et le pathfinding manager 
        // ce script doit juste servire a dire "hey on a cliqué sur une case"
        if(clickCD >= 0 )
        {
            return;
        }
        clickCD = 0.3f;
        if (buttonIndex == 1)
        {
            pathMNG.MovePlayer(index);
        }
        if (buttonIndex == 0)
        {
            // Weapon Manager : lance une attaque sur la salle d'index index;
        }
    }
}
