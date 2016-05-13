using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour {

    public PlayerStats playerStats;
    public EnginesManager engineMng;
    public NavigationHUDMng navHudMng;
    public WeaponHUDMng weaponHudMng;
    public RepairHUDMng repairHudMng;
    public PowerHUDMng pwrHudMng;




	// Use this for initialization
	void Start ()
    {
        StartCoroutine(RepairHullCrt());
        playerStats.engineMng = engineMng;
        repairHudMng.engineMng = engineMng;
        weaponHudMng.engineMng = engineMng;
        navHudMng.engineMng = engineMng;
        pwrHudMng.engineMng = engineMng;

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
    public int GetWeaponsPower()
    {
        if(engineMng != null)
        {
            int weaponPwr = engineMng.GetEngine(Engine.engineType.weapon).currentPwr;
            return weaponPwr;
        }
        else
        {
            return 0;
        }
    }

    public void GetDamage(int amount, ShipRoom targetRoom)
    {
        int trueDamage = playerStats.GetTrueDamage(amount);
        if (trueDamage > 0)
        {
            engineMng.GetDamageOnEngine(targetRoom.engine, trueDamage);
            foreach (ShipCell cell in targetRoom.cells)
            {
                if (cell.crew != null)
                {
                    cell.crew.GetComponent<CharacterManager>().GetDamage(amount);
                }
                if (cell.enemy != null)
                {
                    cell.enemy.GetComponent<CharacterManager>().GetDamage(amount);
                }
            }
        }
    }



    public Engine GetEngine(Engine.engineType engineType)
    {
        return engineMng.GetEngine(engineType);
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
