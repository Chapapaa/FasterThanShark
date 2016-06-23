using UnityEngine;
using System.Collections;

public class EnemyEncounterEvent : MonoBehaviour {

    public EventPanelScript eventPanelScr;
    public int enemyIndex = 0;


	// Use this for initialization
	void Start () {

        eventPanelScr.eventTriggerManager.SpawnEnemy(enemyIndex);


    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
