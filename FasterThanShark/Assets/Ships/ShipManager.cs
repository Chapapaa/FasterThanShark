﻿using UnityEngine;
using System.Collections;

public class ShipManager : MonoBehaviour {

    public GameObject crewSpawn;
    public GameObject crewSpawnContainer;
    public GameObject fullShipSprite;
    public EnginesManager engineManager;






    // Use this for initialization
    void Start () {
        CharSpawnManager spawnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharSpawnManager>();
        spawnManager.spawnPosition = crewSpawn.transform.position;
        spawnManager.mapCrewContainer = crewSpawnContainer;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().engineMng = engineManager;



    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowFullShip()
    {
        fullShipSprite.SetActive(true);
    }
    public void ShowHalfShip()
    {
        fullShipSprite.SetActive(false);
    }


}
