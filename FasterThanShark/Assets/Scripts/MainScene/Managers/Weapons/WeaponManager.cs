using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

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
    // ---------
    public Weapon[] weapons = new Weapon[4];
    // ---------

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

        weaponsPower = playerMng.GetWeaponsPower();
        RefreshPower();
    }

    public bool PowerWeapon(int weaponIndex)
    {
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
        StopAllCoroutines();
    }

    public void UnselectWeapon()
    {
        weaponSelected = -1;
    }

    public void SelectWeapon(int index)
    {
        if(!weapons[index].initialized)
        {
            return;
        }
        if(weapons[index].weaponPwr <= 0)
        {
            PowerWeapon(index);
        }
        clickEvntMng.ResetSelection();
        // change le curseur en mode cible
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
                return;
            }
            if(weapons[weaponSelected].weaponFireCoroutine)
            {
                StopCoroutine(weapons[weaponSelected].fireCoroutine);
            }
            weapons[weaponSelected].fireCoroutine = UseWeaponCRT(weaponSelected, targetPos, _mapIndex);
            StartCoroutine(weapons[weaponSelected].fireCoroutine);

            weaponSelected = -1;
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

    IEnumerator UseWeaponCRT(int weaponIndex, Vector3 targetPosition, int mapIndex)
    {
        weapons[weaponIndex].weaponFireCoroutine = true;
        while(true)
        {
            if(!weapons[weaponIndex].initialized)
            {
                StopAllCoroutines();
            }
            if(weapons[weaponIndex].weaponPwr <= 0)
            {
                break;
            }
            if(weapons[weaponIndex].weaponItem.itemCurrentCD >= weapons[weaponIndex].weaponItem.itemCD)
            {
                if (mapIndex == 1)
                {
                    weaponDisplayMng.Fire(weaponIndex, targetPosition);
                }
                weapons[weaponIndex].weaponItem.itemCurrentCD = 0;
                if(!autoFire)
                {
                    break;
                }
                
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        weapons[weaponIndex].weaponFireCoroutine = false;
    }


    public class Weapon
    {
        public IEnumerator fireCoroutine;
        public Item weaponItem;
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


    public void InitWeaponDisplayMng(GameObject weaponDisplayGO)
    {
        weaponDisplayMng = weaponDisplayGO.GetComponent<WeaponDisplayManager>();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gismoPos, 0.1f);
    }
}
