using UnityEngine;
using System.Collections;

public class ShipSpawnManager : MonoBehaviour {

    public EnemyShipDatabase enemyShipDtb;
    public GameObject enemySpawnPos;


    public GameObject SpawnEnemy()
    {
        GameObject enemyShip =  Instantiate(enemyShipDtb.GetEnemyShip());
        enemyShip.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        enemyShip.transform.position = enemySpawnPos.transform.position;
        AstarPath.active.Scan();
    
        return enemyShip;
    }

    public GameObject SpawnEnemy(GameObject _enemyToSpawn)
    {
        GameObject enemyShip = Instantiate(_enemyToSpawn);
        enemyShip.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        enemyShip.transform.position = enemySpawnPos.transform.position;
        AstarPath.active.Scan();

        return _enemyToSpawn;
    }
}
