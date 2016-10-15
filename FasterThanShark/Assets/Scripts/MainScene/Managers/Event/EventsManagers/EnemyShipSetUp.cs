using UnityEngine;
using System.Collections;

public class EnemyShipSetUp : MonoBehaviour {

    public ItemDatabase itemDtb;

    int enemyDifficulty = 1;


    public void InitShip(GameObject enemyShip, int difficulty)
    {
        enemyDifficulty = difficulty;
        EnemyManager enemyMng = enemyShip.GetComponentInChildren<EnemyManager>();
        EnemyStats enemyStats = enemyShip.GetComponentInChildren<EnemyStats>();
        if (enemyMng == null || enemyStats == null)
        {
            Debug.Log("MISSING ENEMYMANAGER ON SPAWNED SHIP");
            return;
        }
// Set Up du ship en fonction de la difficultée et de la classe.
// nombre de crew
// energy max
// energy max par engine
// nombre d'armes et type d'armes
// nombre et type d'améliorations
// nombre et type de hp
// niveau exp des personnages

    }
}
