using UnityEngine;
using System.Collections;

public class ShipSpawnManager : MonoBehaviour {

    public GameObject enemyPrefab1;


    public GameObject SpawnEnemy()
    {
        GameObject enemyShip =  Instantiate(enemyPrefab1);
        enemyShip.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);

        return enemyShip;
    }
}
