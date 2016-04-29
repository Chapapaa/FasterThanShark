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


    //PlayerManager playerMng;

    public GameObject standardBulletPrefab;





    // Use this for initialization
    void Start ()
    {
        weapon0 = GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemDatabase>().GetItem(2);
        displayMng.weapon0 = weapon0;
        globalMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        //weapon1 = GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemDatabase>().GetItem(2);
        StartCoroutine(UseWeapon0CRT());
        displayMng.RefreshWeapons();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if( weapon0 == null)
        { return; }
        weapon0.itemCurrentCD += Time.deltaTime;
    }

    IEnumerator UseWeapon0CRT()
    {
        ShipRoom aimedRoom = globalMap.GetRandomAllyRoom();
        while (true)
        {
            if(engineMng.isWeaponEngineAlive())
            {  
                if (weapon0.itemCurrentCD >= weapon0.itemCD)
                {
                    aimedRoom = globalMap.GetRandomAllyRoom();
                    displayMng.Fire(0, aimedRoom.roomPosition);
                    weapon0.itemCurrentCD = 0f;
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

}
