using UnityEngine;
using System.Collections;

public class WeaponDisplayManager : MonoBehaviour {

    WeaponManager weaponMng;

    public Item weapon1;
    public Item weapon2;
    public Item weapon3;
    public Item weapon4;

    public GameObject weapon1Container;
    public GameObject weapon2Container;
    public GameObject weapon3Container;
    public GameObject weapon4Container;

    GameObject weapon1Display;
    GameObject weapon2Display;
    GameObject weapon3Display;
    GameObject weapon4Display;

    //Prefabs

    public GameObject standardCannon;



    void Start()
    {
        weaponMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<WeaponManager>();
        weaponMng.InitWeaponDisplayMng(gameObject);
        weaponMng.WeaponDisplayInitialized = true;
    }

    /// <summary>
    /// animation of fireing
    /// </summary>
    /// <param name="weaponID">1,2,3,4</param>
    public void Fire(int weaponID)
    {
        //affiche l'animation de tir avec l'arme choisie
        if(weaponID == 1)
        {
            weapon1Display.GetComponent<Animator>().SetTrigger("Fire");
            //CannonBullletSpawner
            weapon1Display.GetComponent<CannonBullletSpawner>().SpawnBullet();
        }
        if (weaponID == 2)
        {
            weapon2Display.GetComponent<Animator>().SetTrigger("Fire");
            weapon2Display.GetComponent<CannonBullletSpawner>().SpawnBullet();
        }
        if (weaponID == 3)
        {
            weapon3Display.GetComponent<Animator>().SetTrigger("Fire");
            weapon3Display.GetComponent<CannonBullletSpawner>().SpawnBullet();
        }
        if (weaponID == 4)
        {
            weapon4Display.GetComponent<Animator>().SetTrigger("Fire");
            weapon4Display.GetComponent<CannonBullletSpawner>().SpawnBullet();
        }
    }

    public void RefreshWeaponsInDisplay()
    {
        weapon1 = null;
        weapon2 = null;
        weapon3 = null;
        weapon4 = null;
    }
    public void RefreshWeaponDisplay()
    {
        Destroy(weapon1Display);
        Destroy(weapon2Display);
        Destroy(weapon3Display);
        Destroy(weapon4Display);
        if(weapon1 != null)
        {
            // TD : récupere le type d'arme et instancie le bon prefab;
            weapon1Display = Instantiate(standardCannon);
            weapon1Display.transform.SetParent(weapon1Container.transform);
            weapon1Display.transform.localPosition = Vector3.zero;
            weapon1Display.transform.localRotation = weapon1Container.transform.localRotation;
            weapon1Display.GetComponent<CannonBullletSpawner>().direction = 6;
        }
        if (weapon2 != null)
        {
            weapon2Display = Instantiate(standardCannon);
            weapon2Display.transform.SetParent(weapon2Container.transform);
            weapon2Display.transform.localPosition = Vector3.zero;
            weapon2Display.transform.localRotation = weapon1Container.transform.localRotation;
            weapon2Display.GetComponent<CannonBullletSpawner>().direction = 6;
        }
        if (weapon3 != null)
        {
            weapon3Display = Instantiate(standardCannon);
            weapon3Display.transform.SetParent(weapon3Container.transform);
            weapon3Display.transform.localPosition = Vector3.zero;
            weapon3Display.transform.localRotation = weapon1Container.transform.localRotation;
            weapon3Display.GetComponent<CannonBullletSpawner>().direction = 6;
        }
        if (weapon4 != null)
        {
            weapon4Display = Instantiate(standardCannon);
            weapon4Display.transform.SetParent(weapon4Container.transform);
            weapon4Display.transform.localPosition = Vector3.zero;
            weapon4Display.transform.localRotation = weapon1Container.transform.localRotation;
            weapon4Display.GetComponent<CannonBullletSpawner>().direction = 6;
        }
    }
    

}
