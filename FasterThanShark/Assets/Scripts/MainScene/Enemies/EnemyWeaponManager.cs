using UnityEngine;
using System.Collections;

public class EnemyWeaponManager : MonoBehaviour {


    public EnemyWeaponDisplay displayMng;
    public EnginesManager engineMng;
    ShipMap globalMap;

    public Weapon[] weapons = new Weapon[4];
    public int weaponUsedPower = 0;
    public int weaponsPower = 0;
    public int weaponOpeDelayReduc = 10; // en pourcentage du temps de base (100 = aucun delay)

    IEnumerator Weapon0CRT;

    public Item weapon1;
    IEnumerator Weapon1CRT;

    Engine weaponEngine;
    bool isWeaponEngineInit = false;


    //PlayerManager playerMng;

    public GameObject standardBulletPrefab;





    // Use this for initialization
    void Start ()
    {
        globalMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        weapons[0] = new Weapon(GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemDatabase>().GetItem(2));
        weapons[1] = new Weapon();
        weapons[2] = new Weapon();
        weapons[3] = new Weapon(); 
        displayMng.weapon0 = weapons[0].weaponItem;

        
        StartCoroutine(UseWeaponCRT(0,0));
        displayMng.RefreshWeapons();

    }
	
	// Update is called once per frame
	void Update ()
    {

        if (!weapons[0].initialized)
        { print("not init"); return; }
        if (!isWeaponEngineInit)
        {
            print("weaponEngNotInit");
            weaponEngine = engineMng.GetEngine(Engine.engineType.weapon);
            if(weaponEngine != null)
            {
                isWeaponEngineInit = true;
                
            }
            return;
        }
        weaponsPower = weaponEngine.currentPwr;
        RefreshPower();
        PowerWeapon(0);
        PowerWeapon(1);
        PowerWeapon(2);
        PowerWeapon(3);
        //RefreshPower();
        foreach (Weapon wpn in weapons)
        {
            if (wpn.weaponPwr > 0)
            {
                wpn.weaponItem.itemCD = wpn.weaponItem.baseItemCD * ((100 - (weaponEngine.operateLevel * weaponOpeDelayReduc)) / 100f);
                if (wpn.weaponItem.itemCurrentCD < wpn.weaponItem.itemCD)
                {
                    wpn.weaponItem.itemCurrentCD += Time.deltaTime;

                }
            }
        }
    }

    public void RefreshPower()
    {
        if (weapons[0] == null || weapons[1] == null || weapons[2] == null || weapons[3] == null)
        {
            return;
        }
        weaponUsedPower = weapons[0].weaponPwr + weapons[1].weaponPwr + weapons[2].weaponPwr + weapons[3].weaponPwr;
        if (weaponUsedPower > weaponsPower)
        {
            if (weapons[3].weaponPwr > 0)
            {
                UnPowerWeapon(3);
                return;
            }
            if (weapons[2].weaponPwr > 0)
            {
                UnPowerWeapon(2);
                return;
            }
            if (weapons[1].weaponPwr > 0)
            {
                UnPowerWeapon(1);
                return;
            }
            if (weapons[0].weaponPwr > 0)
            {
                UnPowerWeapon(0);
                return;
            }
        }
    }
    public bool PowerWeapon(int weaponIndex)
    {
        if (weapons[weaponIndex].weaponItem == null){ return false; }
        if (weapons[weaponIndex].weaponItem.itemPwrCost + weaponUsedPower <= weaponsPower)
        {
            weapons[weaponIndex].weaponPwr = weapons[weaponIndex].weaponItem.itemPwrCost;
            return true;
        }
        return false;
    }
    public void UnPowerWeapon(int weaponIndex)
    {
        weapons[weaponIndex].weaponPwr = 0;
    }

    IEnumerator UseWeaponCRT(int weaponIndex, int mapIndex)
    {
        
        weapons[weaponIndex].weaponFireCoroutine = true;
        while (true)
        {
            if (weapons[weaponIndex].initialized)
            {
                if (weapons[weaponIndex].weaponPwr > 0)
                {
                    if (weapons[weaponIndex].weaponItem.itemCurrentCD >= weapons[weaponIndex].weaponItem.itemCD && weapons[weaponIndex].weaponPwr > 0)
                    {
                        ShipRoom aimedRoom = globalMap.GetRandomAllyRoom();
                        if (mapIndex == 0)
                        {
                            displayMng.Fire(weaponIndex, aimedRoom.roomPosition, weapons[weaponIndex].weaponItem.itemDamage);
                            weapons[weaponIndex].weaponItem.itemCurrentCD = 0;
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.02f);
        }
    }




    public class Weapon
    {
        public IEnumerator fireCoroutine;
        public Item weaponItem = null;
        public int weaponPwr = 0;
        public bool weaponFireCoroutine;
        public bool initialized = false;

        public Weapon(Item _weaponItem)
        {
            weaponItem = _weaponItem;
            initialized = true;
        }
        public Weapon()
        {
            initialized = false;
        }

    }
}
