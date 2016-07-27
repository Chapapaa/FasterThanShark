using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour {

    EnemyStats statsSCR;
    ShipMap shipMap;
    WeaponManager weaponsMng;
    EventTriggerManager eventsMng;
    EnemyIA iAMng;
    public EnginesManager engineMng;
    public GameObject crewContainer;
    public GameObject crewPrefab;
    public Transform crewSpawnPos;
    public int repairDelay = 40;
    public float repairOpeBonus = 10f; // réduction en pourcentage par level d'opérate 
    public int fleeOperateModifier = 5; // bonus en flat par level d'opérate 




    // Use this for initialization
    void Start ()
    {
        iAMng = GetComponent<EnemyIA>();
        statsSCR = GetComponent<EnemyStats>();
        shipMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        eventsMng = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<EventTriggerManager>();
        weaponsMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<WeaponManager>();
        weaponsMng.enemy = gameObject;
        StartCoroutine(RepairHullCrt());
        StartCoroutine(InitCrew());


    }

    void Update()
    {
        if (engineMng != null)
        {
            Engine navEngine = engineMng.GetEngine(Engine.engineType.navigation);
            if (navEngine != null && navEngine.currentPwr > 0)
            {
                statsSCR.maxFlee = (navEngine.currentPwr * 10) + (navEngine.operateLevel * fleeOperateModifier);
                statsSCR.flee = statsSCR.maxFlee;
            }
            else
            {
                statsSCR.flee = 0;
            }
        }
    }
	
    public void GetDamage(int amount, ShipRoom targetRoom)
    {
        int trueDamage = statsSCR.GetDamage(amount);

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

    public void Death()
    {
        shipMap.ResetEnemyShipMap();
        DestroyCrews();
        eventsMng.EnemyDeath();
        Destroy(gameObject);
    }

    void DestroyCrews()
    {
        CharacterManager[] crewManagerss = crewContainer.GetComponentsInChildren<CharacterManager>();
        //GameObject[] crews = GameObject.FindGameObjectsWithTag("Character");
        foreach (var crew in crewManagerss)
        {
            crew.Death();
        }
    }

    IEnumerator RepairHullCrt()
    {

        int repairProgress = 0;
        while (true)
        {
            if (engineMng != null)
            {
                Engine repairEngine = engineMng.GetEngine(Engine.engineType.repair);
                if(repairEngine != null)
                {
                    if (repairEngine.currentPwr > 0)
                    {
                        if (statsSCR.health2 < statsSCR.maxHealth2)
                        {
                            repairProgress += 1;
                            float repairMax = repairDelay * ((100 - (repairOpeBonus * repairEngine.operateLevel)) / 100f);
                            if (repairProgress >= repairMax)
                            {
                                statsSCR.health2 += 1;
                                repairProgress = 0;
                            }
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator InitCrew()
    {
        yield return new WaitForSeconds(0.2f);
        GameObject instCrew = Instantiate(crewPrefab);
        instCrew.transform.SetParent(crewContainer.transform);
        instCrew.transform.position = crewSpawnPos.position;
        iAMng.AddCrewToIA(instCrew);
        GameObject inst2Crew = Instantiate(crewPrefab);
        inst2Crew.transform.SetParent(crewContainer.transform);
        inst2Crew.transform.position = crewSpawnPos.position;
        iAMng.AddCrewToIA(inst2Crew);
        //GameObject inst3Crew = Instantiate(crewPrefab);
        //inst3Crew.transform.SetParent(crewContainer.transform);
        //inst3Crew.transform.position = crewSpawnPos.position;
        //iAMng.AddCrewToIA(inst3Crew);
        //GameObject inst4Crew = Instantiate(crewPrefab);
        //inst4Crew.transform.SetParent(crewContainer.transform);
        //inst4Crew.transform.position = crewSpawnPos.position;
        //iAMng.AddCrewToIA(inst4Crew);
        //GameObject inst5Crew = Instantiate(crewPrefab);
        //inst5Crew.transform.SetParent(crewContainer.transform);
        //inst5Crew.transform.position = crewSpawnPos.position;
        //iAMng.AddCrewToIA(inst5Crew);

    }



    // TD : Fonction de setUP;




}
