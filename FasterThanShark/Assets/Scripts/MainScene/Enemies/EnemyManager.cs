using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    EnemyStats statsSCR;
    ShipMap shipMap;
    WeaponManager weaponsMng;
    EventsManager eventsMng;
    public EnginesManager engineMng;
    public GameObject crewContainer;
    



	// Use this for initialization
	void Start ()
    {
        statsSCR = GetComponent<EnemyStats>();
        shipMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        eventsMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<EventsManager>();
        weaponsMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<WeaponManager>();
        weaponsMng.enemy = gameObject;
        StartCoroutine(RepairHullCrt());

    }
	
    public void GetDamage(int amount, Vector3 position)
    {
        int trueDmanage = statsSCR.GetDamage(amount);
        ShipRoom damagedRoom = shipMap.GetRoomByPos(position);
        if(damagedRoom != null)
        { 
            engineMng.GetDamageOnEngine(damagedRoom.engine, trueDmanage);
        }
    }

    public void Death()
    {
        shipMap.ResetEnemyShipMap();
        DestroyCrews();
        eventsMng.EnemyDestroyed();
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
                if (engineMng.IsRepairEngineAlive())
                {
                    if (statsSCR.health2 < statsSCR.maxHealth2)
                    {
                        repairProgress += 1;
                        if (repairProgress >= 40)
                        {
                            statsSCR.health2 += 1;
                            repairProgress = 0;
                        }
                    }
                }

            }
            yield return new WaitForSeconds(0.1f);
        }
    }


}
