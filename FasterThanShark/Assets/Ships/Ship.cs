using UnityEngine;
using System.Collections;

public class Ship {

    public int shipID;
    public shipType type;
    public GameObject shipGO;


    public enum shipType
    {
        standard,
        pirate
    }
	
    public Ship(int _shipID, shipType _type, GameObject _shipGO)
    {
        shipID = _shipID;
        type = _type;
        shipGO = _shipGO;
    }

}
