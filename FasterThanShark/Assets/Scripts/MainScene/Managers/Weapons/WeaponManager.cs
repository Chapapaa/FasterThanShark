using System.Collections;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    public CursorManager cursorMng;
    public ItemInventory playerInventory;
    public ClickEventManager clickEvntMng;
    public GameObject enemy;
    public bool autoFire;

    public GameObject bulletPrefab;

    public bool WeaponDisplayInitialized = false;
    public BulletSpawnerManager bulletSpawnerMng;
    WeaponDisplayManager weaponDisplayMng;

    public int weaponSelected = -1;

    Vector3 gismoPos = new Vector3(100f, 100f, 0f);

    public PlayerManager playerMng;
    public int weaponUsedPower = 0;
    public int weaponsPower = 0;
    public int weaponOpeDelayReduc = 10; // en pourcentage du temps de base (100 = aucun delay)

    public GameObject targetIcon1;
    public GameObject targetIcon2;
    
    // ---------
    public Weapon[] weapons = new Weapon[4];
    // ---------

    Engine weaponEngine;
    bool isWeaponEngineInit = false;

    // Use this for initialization
    void Start ()
    {
        weapons[0] = new Weapon();
        weapons[1] = new Weapon();
        weapons[2] = new Weapon();
        weapons[3] = new Weapon();
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            SelectWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            SelectWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            SelectWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            SelectWeapon(3);
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            UnselectWeapon();
        }

        weaponsPower = playerMng.GetWeaponsPower();
        RefreshPower();

        if (!isWeaponEngineInit)
        {
            weaponEngine = playerMng.GetEngine(Engine.engineType.weapon);
            if(weaponEngine != null)
            {
                isWeaponEngineInit = true;
            }
        }
        else
        {

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
    }

    public bool PowerWeapon(int weaponIndex)
    {
        if(weapons[weaponIndex].weaponItem.itemPwrCost + weaponUsedPower > weaponsPower)
        {
            playerMng.PowerEngine(Engine.engineType.weapon, weapons[weaponIndex].weaponItem.itemPwrCost);
            weaponsPower = playerMng.GetWeaponsPower();
        }
        if (weapons[weaponIndex].weaponItem.itemPwrCost + weaponUsedPower <= weaponsPower)
        {
            weapons[weaponIndex].weaponPwr = weapons[weaponIndex].weaponItem.itemPwrCost;
            return true;
        }
        return false;        
    }

    public void UnPowerWeapon(int weaponIndex)
    {
        UnselectWeapon();
        weapons[weaponIndex].weaponPwr = 0;
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
            if(weapons[3].weaponPwr > 0)
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

    public void StopAttacking()
    {
        weapons[0].ClearTargetIcon();
        weapons[1].ClearTargetIcon();
        weapons[2].ClearTargetIcon();
        weapons[3].ClearTargetIcon();
        StopAllCoroutines();
    }

    public void UnselectWeapon()
    {
        weaponSelected = -1;
        cursorMng.ChangeCursor("default");
    }

    public void SelectWeapon(int index)
    {
        
        if (!weapons[index].initialized)
        {
            return;
        }
        if(weapons[index].weaponPwr <= 0)
        {
            PowerWeapon(index);
        }
        clickEvntMng.ResetSelection();
        weapons[index].ClearTargetIcon();
        if (weapons[index].weaponFireCoroutine)
        {
            StopCoroutine(weapons[index].fireCoroutine);
            weapons[index].weaponFireCoroutine = false;
        }
        if (weapons[index].weaponPwr > 0)
        {
            if (autoFire)
            {
                cursorMng.ChangeCursor("battle2");
            }
            else
            {
                cursorMng.ChangeCursor("battle1");
            }
        }
        // selectionne l'arme
        weaponSelected = index;
        Debug.Log("Weapon selected : " + index);
    }

    public void UseWeapon(int index, int _mapIndex, Vector3 targetPos)
    {        
        if(_mapIndex == 1 && weaponSelected != -1)
        {
            // map valide, arme valide,
            if (enemy == null)
            { return; }
            // enemy valide,
            //--------
            if(!weapons[weaponSelected].initialized || weapons[weaponSelected].weaponPwr <= 0)
            {
                UnselectWeapon();
                return;
            }
            if(weapons[weaponSelected].weaponFireCoroutine)
            {
                StopCoroutine(weapons[weaponSelected].fireCoroutine);
                weapons[weaponSelected].ClearTargetIcon();
            }
            weapons[weaponSelected].fireCoroutine = UseWeaponCRT(weaponSelected, targetPos, _mapIndex, autoFire);
            StartCoroutine(weapons[weaponSelected].fireCoroutine);

            UnselectWeapon();
            gismoPos = targetPos;
        }
    }

    public void RefreshWeapons()
    {
        if(!WeaponDisplayInitialized)
        { return; }
        weapons[0] = new Weapon();
        weapons[1] = new Weapon();
        weapons[2] = new Weapon();
        weapons[3] = new Weapon();
        weaponDisplayMng.RefreshWeaponsInDisplay(); // enleve toutes les armes du displayMng

        for (int i = 0; i < playerInventory.playerWeaponInventory.Count; i++ )
        {
            switch(i)
            {
                case 0:
                    {
                        weapons[0] = new Weapon(playerInventory.playerWeaponInventory[i]);
                        weapons[0].initialized = true;
                        weaponDisplayMng.weapon1 = weapons[0].weaponItem;
                        break;
                    }
                case 1:
                    {
                        weapons[1] = new Weapon(playerInventory.playerWeaponInventory[i]);
                        weapons[1].initialized = true;
                        weaponDisplayMng.weapon2 = weapons[1].weaponItem;
                        break;
                    }
                case 2:
                    {
                        weapons[2] = new Weapon(playerInventory.playerWeaponInventory[i]);
                        weapons[2].initialized = true;
                        weaponDisplayMng.weapon3 = weapons[2].weaponItem;
                        break;
                    }
                case 3:
                    {
                        weapons[3] = new Weapon(playerInventory.playerWeaponInventory[i]);
                        weapons[3].initialized = true;
                        weaponDisplayMng.weapon4 = weapons[3].weaponItem;
                        break;
                    }
            }
        }
        weaponDisplayMng.RefreshWeaponDisplay(); // enleve les display et les reaffiche correctement
    }

    public void InitWeaponDisplayMng(GameObject weaponDisplayGO)
    {
        weaponDisplayMng = weaponDisplayGO.GetComponent<WeaponDisplayManager>();
    }

    IEnumerator UseWeaponCRT(int weaponIndex, Vector3 targetPosition, int mapIndex, bool _autoFire)
    {

        weapons[weaponIndex].weaponFireCoroutine = true;
        while(true)
        {

            if(!weapons[weaponIndex].initialized)
            {
                weapons[weaponIndex].ClearTargetIcon();
                StopAllCoroutines();
            }
            if (enemy == null)
            { break; }
            if (weapons[weaponIndex].weaponPwr <= 0)
            {
                break;
            }
            if(_autoFire)
            {
                if(weapons[weaponIndex].targetIcon == null)
                {
                    weapons[weaponIndex].ClearTargetIcon();
                    GameObject instTargetIcon = Instantiate(targetIcon2);
                    instTargetIcon.transform.position = targetPosition;
                    weapons[weaponIndex].targetIcon = instTargetIcon;
                }
            }
            else
            {
                if (weapons[weaponIndex].targetIcon == null)
                {
                    weapons[weaponIndex].ClearTargetIcon();
                    GameObject instTargetIcon = Instantiate(targetIcon1);
                    instTargetIcon.transform.position = targetPosition;
                    weapons[weaponIndex].targetIcon = instTargetIcon;
                }
            }
            if(weapons[weaponIndex].weaponItem.itemCurrentCD >= weapons[weaponIndex].weaponItem.itemCD)
            {
                if (mapIndex == 1)
                {
                    if (enemy == null)
                    { break; }
                    weaponDisplayMng.Fire(weaponIndex, targetPosition, weapons[weaponIndex].weaponItem.itemDamage);
                    if(weaponEngine.operated && weaponEngine.operatedBy != null)
                    {
                        GameObject characterOp = weaponEngine.operatedBy;
                        characterOp.GetComponent<CharacterManager>().GainExp(Engine.engineType.weapon);
                    }
                    weapons[weaponIndex].weaponItem.itemCurrentCD = 0;
                    if (!_autoFire)
                    {
                        break;
                    }
                }
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        weapons[weaponIndex].ClearTargetIcon();
        weapons[weaponIndex].weaponFireCoroutine = false;
    }


    public class Weapon
    {
        public IEnumerator fireCoroutine;
        public Item weaponItem;
        public int weaponPwr = 0;
        public bool weaponFireCoroutine;
        public bool initialized = false;
        public GameObject targetIcon = null;

        public Weapon(Item _weaponItem)
        {
            weaponItem = _weaponItem;
            initialized = true;
        }
        public Weapon()
        {
            initialized = false;
        }
        public void ClearTargetIcon()
        {
            if (targetIcon != null)
            {
                DestroyImmediate(targetIcon);
                targetIcon = null;
            }
        }
        
    }


    

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gismoPos, 0.1f);
    }
}
