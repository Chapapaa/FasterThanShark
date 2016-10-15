using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShipDatabase : MonoBehaviour {

    public GameObject[] enemyPrefabs;

    public List<Ship> ships = new List<Ship>();

    void Start()
    {
        ships.Add(new Ship(0, Ship.shipType.pirate, enemyPrefabs[0]));
        ships.Add(new Ship(0, Ship.shipType.standard, enemyPrefabs[1]));
    }

    public GameObject GetEnemyShip()
    {
        int rdm = Random.Range(0, ships.Count);
        return ships[rdm].shipGO;
    }
    public GameObject GetEnemyShip(Ship.shipType _type)
    {
        List<Ship> shipOfType = new List<Ship>();
        foreach(Ship ship in ships)
        {
            if(ship.type == _type)
            {
                shipOfType.Add(ship);
            }
        }

        int rdm = Random.Range(0, shipOfType.Count);
        if(shipOfType.Count > 0)
        {
            return shipOfType[rdm].shipGO;
        }
        return null;
    }

    public GameObject GetEnemyShip(int shipID)
    {
        foreach(Ship ship in ships)
        {
            if(ship.shipID == shipID)
            {
                return ship.shipGO;
            }
        }
        return null;
    }

    // TD : overflow pour récuperation par classe (et ou par nom ?).




}
