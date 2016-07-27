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
    public MedicHUDMng medicHudMng;

    public float maxRepairProgress = 40f;
    public int repairOperateRatio = 10; // réduction du delay de recharge en pourcentage (100 = recharge instant);

    public float modifiedMaxRepairProgress;




    // Use this for initialization
    void Start ()
    {
        StartCoroutine(RepairHullCrt());
        playerStats.engineMng = engineMng;
        repairHudMng.engineMng = engineMng;
        weaponHudMng.engineMng = engineMng;
        navHudMng.engineMng = engineMng;
        pwrHudMng.engineMng = engineMng;
        medicHudMng.engineMng = engineMng;

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
        if(playerStats.maxHealth2 > 0)
        {
            Engine repairEngine = engineMng.GetEngine(Engine.engineType.repair);
            if (repairEngine.operated)
            {
                if (repairEngine.operatedBy != null)
                {
                    repairEngine.operatedBy.GetComponent<CharacterManager>().GainExp(Engine.engineType.repair);
                }
            }
        }
        if (trueDamage > 0)
        {
            engineMng.GetDamageOnEngine(targetRoom.engine, trueDamage);
            GameObject[] chars = GameObject.FindGameObjectsWithTag("Character");
            foreach (GameObject myChar in chars)
            {
                if (Vector3.Distance(myChar.transform.position, targetRoom.roomPosition) < 0.45f)
                {
                    myChar.GetComponent<CharacterManager>().GetDamage(trueDamage);
                }
                else
                {
                    foreach (ShipCell cell in targetRoom.cells)
                    {
                        if (Vector3.Distance(myChar.transform.position, cell.position) < 0.45f)
                        {
                            myChar.GetComponent<CharacterManager>().GetDamage(trueDamage);
                        }
                    }
                }
            }
        }
    }

    public void Flee()
    {
        Engine navEngine = engineMng.GetEngine(Engine.engineType.navigation);
        if (navEngine.operated)
        {
            if(navEngine.operatedBy != null)
            {
                navEngine.operatedBy.GetComponent<CharacterManager>().GainExp(Engine.engineType.navigation);
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
                        Engine repairEngine = engineMng.GetEngine(Engine.engineType.repair);
                        if(repairEngine != null)
                        {
                            modifiedMaxRepairProgress = maxRepairProgress * ((100 - (repairEngine.operateLevel * repairOperateRatio)) / 100f);
                            if (repairProgress >= modifiedMaxRepairProgress)
                            {
                                playerStats.health2 += 1;
                                repairProgress = 0;
                            }
                        }
                        
                    }
                }

            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
