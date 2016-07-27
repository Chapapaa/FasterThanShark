using UnityEngine;
using System.Collections;

public class EnemyShipSetUp : MonoBehaviour {

    public int enemyDifficulty = 1;


    public void InitShip(GameObject enemyShip)
    {
        EnemyManager enemyMng = enemyShip.GetComponentInChildren<EnemyManager>();
        if(enemyMng == null)
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
