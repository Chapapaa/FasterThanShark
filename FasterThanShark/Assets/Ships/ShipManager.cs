using UnityEngine;
using System.Collections;

public class ShipManager : MonoBehaviour {

    public GameObject crewSpawn;
    public GameObject crewSpawnContainer;
    public EnginesManager engineManager;

    EventsManager eventsManager;




    // Use this for initialization
    void Start () {
        CharSpawnManager spawnManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharSpawnManager>();
        spawnManager.spawnPosition = crewSpawn.transform.position;
        spawnManager.mapCrewContainer = crewSpawnContainer;
        eventsManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<EventsManager>();
        eventsManager.mainShip = gameObject;

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().engineMng = engineManager;



    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
