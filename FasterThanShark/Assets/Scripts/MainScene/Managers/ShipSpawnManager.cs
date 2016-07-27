using UnityEngine;
using System.Collections;

public class ShipSpawnManager : MonoBehaviour {

    public EnemyShipDatabase enemyShipDtb;


    public GameObject SpawnEnemy()
    {
        GameObject enemyShip =  Instantiate(enemyShipDtb.GetEnemyShip());
        enemyShip.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
        AstarPath.active.Scan();
    
        return enemyShip;
    }
}
