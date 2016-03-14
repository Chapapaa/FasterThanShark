using UnityEngine;
using System.Collections;

public class EnemyWeaponManager : MonoBehaviour {


    public EnemyWeaponDisplay displayMng;
    public EnginesManager engineMng;
    ShipMap globalMap;

    public Item weapon0;
    IEnumerator Weapon0CRT;
    public Item weapon1;
    IEnumerator Weapon1CRT;


    PlayerManager playerMng;





    // Use this for initialization
    void Start ()
    {
        weapon0 = GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemDatabase>().GetItem(2);
        displayMng.weapon0 = weapon0;
        globalMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        //weapon1 = GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemDatabase>().GetItem(2);
        playerMng = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();

        StartCoroutine(UseWeapon0CRT());

        displayMng.RefreshWeapons();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if( weapon0 == null)
        { return; }
        weapon0.itemCurrentCD += Time.deltaTime;
        //weapon1.itemCurrentCD += Time.deltaTime;


    }

    //IEnumerator AttackCrt()
    //{
    //    while (true)

    //    {
    //        if (weapon0 == null || weapon1 == null)
    //        {
    //            Debug.Log("weapons not loaded");
    //            break;
    //        }

    //        yield return new WaitForSeconds(0.1f);
    //    }
    //}

    IEnumerator UseWeapon0CRT()
    {
        print("fire");
        ShipRoom aimedRoom = globalMap.GetRandomAllyRoom();
        while (true)
        {

            if(engineMng.isWeaponEngineAlive())
            {  
                // print(weapon0.itemCurrentCD + " / " + weapon0.itemCD);
                if (weapon0.itemCurrentCD >= weapon0.itemCD)
                {
                    displayMng.Fire(0);
                    // animation de degats subis
                    playerMng.GetDamage(weapon0.itemDamage, aimedRoom);
                    print(aimedRoom.roomPosition);
                    weapon0.itemCurrentCD = 0f;
                    aimedRoom = globalMap.GetRandomAllyRoom();
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

}
