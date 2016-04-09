using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public PlayerStats playerStats;
    public EnginesManager engineMng;

    public void GetDamage(int amount, ShipRoom targetRoom)
    {
        int trueDamage = playerStats.GetTrueDamage(amount);
        if(trueDamage > 0)
        {
            engineMng.GetDamageOnEngine(targetRoom.engine, trueDamage);
        }
    }


	// Use this for initialization
	void Start ()
    {
        StartCoroutine(RepairHullCrt());
    }
	
	// Update is called once per frame
	void Update () {
        if (engineMng != null)
        {
            if (engineMng.isNavigationEngineAlive())
            {
                // TD : recupere la bonne valeur de flee;
                playerStats.flee = playerStats.maxFlee;
            }
            else
            {
                playerStats.flee = 0;
            }
        }
	
	}

    IEnumerator RepairHullCrt()
    {

        int repairProgress = 0;
        while (true)
        {
            if (engineMng != null)
            {
                if (engineMng.IsRepairEngineAlive())
                {
                    if (playerStats.health2 < playerStats.maxHealth2)
                    {
                        repairProgress += 1;
                        if (repairProgress >= 40)
                        {
                            playerStats.health2 += 1;
                            repairProgress = 0;
                        }
                    }
                }

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
