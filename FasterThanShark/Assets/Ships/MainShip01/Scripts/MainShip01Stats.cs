using UnityEngine;
using System.Collections;

public class MainShip01Stats : MonoBehaviour {

    public int crewNumber;
    CharSpawnManager charSpawnMng;

	// Use this for initialization
	void Start () {
        charSpawnMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharSpawnManager>();

        charSpawnMng.SpawnAlly("Crew n1");
        charSpawnMng.SpawnAlly("Crew n2");
        charSpawnMng.SpawnAlly("Crew n3");
        charSpawnMng.SpawnAlly("Crew n4");

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
