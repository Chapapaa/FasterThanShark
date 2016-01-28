using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

    public ItemInventory playerInventory;
    public ClickEventManager clickEvntMng;
    public GameObject enemy;

    public int weaponSelected = -1;

    Vector3 gismoPos = new Vector3(100f, 100f, 0f);



    // Weapon 1 :
    Item weapon1;
    IEnumerator Weapon1CRT;
    bool Weapon1CRTIsRunning;
    int weapon1Dmg = 0;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
        print("Weapon selected : " + index);
    }


    public void UseWeapon(int index, int _mapIndex, Vector3 targetPos)
    {
        Debug.Log("tentative d'atk");
        if(_mapIndex == 1 && weaponSelected != -1)
        {
            Debug.Log("map ok, weapon ok");
            if (enemy == null)
            { return; }
            if (index == 0)
            {
                if(Weapon1CRTIsRunning)
                {
                    StopCoroutine(Weapon1CRT);
                }
                Weapon1CRT = UseWeapon1CRT(targetPos, _mapIndex);
                StartCoroutine(Weapon1CRT);
            }
            weaponSelected = -1;
            gismoPos = targetPos;
        }
    }



    IEnumerator UseWeapon1CRT(Vector3 targetPosition, int mapIndex)
    {

        Debug.Log(targetPosition + mapIndex.ToString());
        Weapon1CRTIsRunning = true;
        while (true)
        {
            if (weapon1.itemCurrentCD >= weapon1.itemCD)
            {
                if(mapIndex == 1)
                {
                    enemy.GetComponent<EnemyStats>().GetDamage(weapon1.itemDamage);
                }
                // ça fait boom sur la target
                weapon1.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon1CRTIsRunning = false;
    }

    IEnumerator UseWeapon2CRT(int weaponIndex, Vector3 targetPosition)
    {
        Weapon1CRTIsRunning = true;
        while (true)
        {
            if (weapon1.itemCurrentCD >= weapon1.itemCD)
            {
                // ça fait boom sur la target
                weapon1.itemCurrentCD = 0f;
                break;
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
        Weapon1CRTIsRunning = false;
    }

    public void RefreshWeapons()
    {
        if(playerInventory.playerWeaponInventory[0] != null)
        {
            weapon1 = playerInventory.playerWeaponInventory[0];
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(gismoPos, 0.1f);
    }
}
