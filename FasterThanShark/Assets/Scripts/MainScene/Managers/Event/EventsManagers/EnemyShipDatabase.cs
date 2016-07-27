using UnityEngine;
using System.Collections;

public class EnemyShipDatabase : MonoBehaviour {

    public GameObject[] enemyPrefabs;



    public GameObject GetEnemyShip()
    {
        int rdm = Random.Range(0, enemyPrefabs.Length);
        return enemyPrefabs[rdm];
    }

    public GameObject GetEnemyShip(int shipID)
    {
        if(shipID < enemyPrefabs.Length)
        {
            return enemyPrefabs[shipID];
        }
        else
        {
            return null;
        }
    }

    // TD : overflow pour récuperation par classe (et ou par nom ?).




}
