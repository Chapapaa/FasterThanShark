using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public ItemInventory playerInventory;
    public ClickEventManager clickEvntMng;
    public GameObject enemy;

    public GameObject bulletPrefab;

    public bool WeaponDisplayInitialized = false;
    public BulletSpawnerManager bulletSpawnerMng;
    WeaponDisplayManager weaponDisplayMng;

    public int weaponSelected = -1;

    Vector3 gismoPos = new Vector3(100f, 100f, 0f);

    // Weapon 1 :
    Item weapon1;
    IEnumerator Weapon1CRT;
    bool Weapon1CRTIsRunning;
    // Weapon 2 :
    Item weapon2;
    IEnumerator Weapon2CRT;
    bool Weapon2CRTIsRunning;
    // Weapon 3 :
    Item weapon3;
    IEnumerator Weapon3CRT;
    bool Weapon3CRTIsRunning;
    // Weapon 4 :
    Item weapon4;
    IEnumerator Weapon4CRT;
    bool Weapon4CRTIsRunning;



    // Use this for initialization
    void Start () {
	
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
            // Arme 1:
            if (weaponSelected == 0)
            {
                if(weapon1 == null)         
                { return; }
                if(Weapon1CRTIsRunning)
                {
                    StopCoroutine(Weapon1CRT);
                }
                Weapon1CRT = UseWeapon1CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon1CRT);
            }
            // Arme 2:
            if (weaponSelected == 1)
            {
                if (weapon2 == null)         
                { return; }
                if (Weapon2CRTIsRunning)
                {
                    StopCoroutine(Weapon2CRT);
                }
                Weapon2CRT = UseWeapon2CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon2CRT);
            }
            // Arme 3:
            if (weaponSelected == 2)
            {
                if (weapon3 == null)
                { return; }
                if (Weapon3CRTIsRunning)
                {
                    StopCoroutine(Weapon3CRT);
                }
                Weapon3CRT = UseWeapon3CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon3CRT);
            }
            // Arme 4:
            if (weaponSelected == 3)
            {
                if (weapon4 == null)
                { return; }
                if (Weapon4CRTIsRunning)
                {
                    StopCoroutine(Weapon4CRT);
                }
                Weapon4CRT = UseWeapon4CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon4CRT);
            }
            // Fin de l'attaque
            weaponSelected = -1;
            gismoPos = targetPos;
        }
    }

    public void RefreshWeapons()
    {
        if(!WeaponDisplayInitialized)
        { return; }
        weapon1 = null;
        weapon2 = null;
        weapon3 = null;
        weapon4 = null;
        weaponDisplayMng.RefreshWeaponsInDisplay(); // enleve toutes les armes du displayMng

        for (int i = 0; i < playerInventory.playerWeaponInventory.Count; i++ )
        {
            switch(i)
            {
                case 0:
                    {
                        weapon1 = playerInventory.playerWeaponInventory[i];
                        weaponDisplayMng.weapon1 = weapon1;
                        break;
                    }
                case 1:
                    {
                        weapon2 = playerInventory.playerWeaponInventory[i];
                        weaponDisplayMng.weapon2 = weapon2;
                        break;
                    }
                case 2:
                    {
                        weapon3 = playerInventory.playerWeaponInventory[i];
                        weaponDisplayMng.weapon3 = weapon3;
                        break;
                    }
                case 3:
                    {
                        weapon4 = playerInventory.playerWeaponInventory[i];
                        weaponDisplayMng.weapon4 = weapon4;
                        break;
                    }
            }
        }
        weaponDisplayMng.RefreshWeaponDisplay(); // enleve les display et les reaffiche correctement
    }

    IEnumerator UseWeapon1CRT(Vector3 targetPosition, int mapIndex)
    {

        Weapon1CRTIsRunning = true;
        while (true)
        {
            if (weapon1.itemCurrentCD >= weapon1.itemCD)
            {
                if (mapIndex == 1)
                {
                    //
                    weaponDisplayMng.Fire(1, targetPosition);

                }
                weapon1.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon1CRTIsRunning = false;
    }

    IEnumerator UseWeapon2CRT(Vector3 targetPosition, int mapIndex)
    {
        Weapon2CRTIsRunning = true;
        while (true)
        {
            if (weapon2.itemCurrentCD >= weapon2.itemCD)
            {
                if (mapIndex == 1)
                {
                    //
                    weaponDisplayMng.Fire(2, targetPosition);
                    //
                    //bulletSpawnerMng.SpawnBulletOnEnemy(weapon2.itemDamage, bulletPrefab, targetPosition);
                    //enemy.GetComponent<EnemyManager>().GetDamage(weapon2.itemDamage, targetPosition);
                }
                weapon2.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon2CRTIsRunning = false;
    }
    IEnumerator UseWeapon3CRT(Vector3 targetPosition, int mapIndex)
    {
        Weapon3CRTIsRunning = true;
        while (true)
        {
            if (weapon3.itemCurrentCD >= weapon3.itemCD)
            {
                if (mapIndex == 1)
                {
                    //
                    weaponDisplayMng.Fire(3, targetPosition);
                    //
                    //bulletSpawnerMng.SpawnBulletOnEnemy(weapon3.itemDamage, bulletPrefab, targetPosition);
                    //enemy.GetComponent<EnemyManager>().GetDamage(weapon3.itemDamage, targetPosition);
                }
                weapon3.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon3CRTIsRunning = false;
    }
    IEnumerator UseWeapon4CRT(Vector3 targetPosition, int mapIndex)
    {
        Weapon4CRTIsRunning = true;
        while (true)
        {
            if (weapon4.itemCurrentCD >= weapon4.itemCD)
            {
                if (mapIndex == 1)
                {
                    //
                    weaponDisplayMng.Fire(4, targetPosition);
                    //
                    //bulletSpawnerMng.SpawnBulletOnEnemy(weapon4.itemDamage, bulletPrefab, targetPosition);
                    //enemy.GetComponent<EnemyManager>().GetDamage(weapon4.itemDamage, targetPosition);
                }
                weapon4.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon4CRTIsRunning = false;
    }

    //IEnumerator Fire(Item weapon)
    //{
    //    /*
    //        Animation de tir;
    //        attends qq secondes 
    //        animation de vaisseau enemy touché
    //        fin
    //    */
    //    yield return new WaitForSeconds(0.1f);
    //}


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
