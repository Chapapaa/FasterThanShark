﻿using UnityEngine;
using System.Collections;

public class EnemyWeaponDisplay : MonoBehaviour {


    public Item weapon0;
    public Item weapon1;
    public Item weapon2;
    public Item weapon3;

    public GameObject weapon0Container;
    public GameObject weapon1Container;
    public GameObject weapon2Container;
    public GameObject weapon3Container;

    public float baseRotationDegree;

    GameObject weapon0Display;
    GameObject weapon1Display;
    GameObject weapon2Display;
    GameObject weapon3Display;

    //Prefabs

    public GameObject standardCannon;

    /// <summary>
    /// animation of fireing
    /// </summary>
    /// <param name="weaponID">0,1,2,3</param>
    public void Fire(int weaponID, Vector3 _targetPos, int weaponDamage)
    {
        //affiche l'animation de tir avec l'arme choisie
        if (weaponID == 0)
        {
            weapon0Display.GetComponent<Animator>().SetTrigger("Fire");          
            weapon0Display.GetComponent<CannonBullletSpawner>().SpawnBullet(_targetPos, 0, weaponDamage);
            weapon0Display.transform.localRotation = Quaternion.identity;
            Vector3 dir = _targetPos - weapon0Display.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weapon0Display.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        // Inutilisé pour le moment
        if (weaponID == 1)
        {
            weapon1Display.GetComponent<Animator>().SetTrigger("Fire");
            weapon1Display.GetComponent<CannonBullletSpawner>().SpawnBullet(_targetPos, 0, weaponDamage);
            weapon1Display.transform.localRotation = Quaternion.identity;
            Vector3 dir = _targetPos - weapon1Display.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weapon1Display.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        if (weaponID == 2)
        {
            weapon2Display.GetComponent<Animator>().SetTrigger("Fire");
            weapon2Display.GetComponent<CannonBullletSpawner>().SpawnBullet(_targetPos, 0, weaponDamage);
            weapon2Display.transform.localRotation = Quaternion.identity;
            Vector3 dir = _targetPos - weapon2Display.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weapon2Display.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }
        if (weaponID == 3)
        {
            weapon3Display.GetComponent<Animator>().SetTrigger("Fire");
            weapon3Display.GetComponent<CannonBullletSpawner>().SpawnBullet(_targetPos, 0, weaponDamage);
            weapon3Display.transform.localRotation = Quaternion.identity;
            Vector3 dir = _targetPos - weapon3Display.transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weapon3Display.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    

    // Use this for initialization
    void Start () {
        

    }

    public void RefreshWeapons()
    {
        if (weapon0 != null)
        {
            // TD : récupere le type d'arme et instancie le bon prefab;
            weapon0Display = Instantiate(standardCannon);
            weapon0Display.transform.SetParent(weapon0Container.transform);
            weapon0Display.transform.localPosition = Vector3.zero;
            weapon0Display.transform.localRotation = Quaternion.Euler(0f, 0f, baseRotationDegree);
        }
        if (weapon1 != null)
        {
            weapon1Display = Instantiate(standardCannon);
            weapon1Display.transform.SetParent(weapon1Container.transform);
            weapon1Display.transform.localPosition = new Vector3(0f, 0f, 0.1f);
            weapon1Display.transform.localRotation = Quaternion.Euler(0f, 0f, baseRotationDegree);
        }
        if (weapon2 != null)
        {
            weapon2Display = Instantiate(standardCannon);
            weapon2Display.transform.SetParent(weapon2Container.transform);
            weapon2Display.transform.localPosition = new Vector3(0f, 0f, 0.1f);
            weapon2Display.transform.localRotation = Quaternion.Euler(0f, 0f, baseRotationDegree);
        }
        if (weapon3 != null)
        {
            weapon3Display = Instantiate(standardCannon);
            weapon3Display.transform.SetParent(weapon3Container.transform);
            weapon3Display.transform.localPosition = new Vector3(0f, 0f, 0.1f);
            weapon3Display.transform.localRotation = Quaternion.Euler(0f, 0f, baseRotationDegree);
        }

    }

	
	// Update is called once per frame
	void Update () {
	
	}
}
