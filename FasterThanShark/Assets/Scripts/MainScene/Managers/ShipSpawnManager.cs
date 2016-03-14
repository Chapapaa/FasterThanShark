using UnityEngine;
using System.Collections;

public class ShipSpawnManager : MonoBehaviour {

    public GameObject enemyPrefab1;


    public GameObject SpawnEnemy()
    {
        GameObject enemyShip =  Instantiate(enemyPrefab1);
        return enemyShip;
    }
}
