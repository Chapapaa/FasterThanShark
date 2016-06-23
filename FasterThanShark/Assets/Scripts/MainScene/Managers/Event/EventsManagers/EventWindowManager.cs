using UnityEngine;
using System.Collections;

public class EventWindowManager : MonoBehaviour {

    public GameObject startGameEvent;
    public GameObject shipDeathEvent;
    public GameObject enemyDeathEvent;
    public GameObject escapeEvent;

    public GameObject shopEvent;

    public GameObject[] simpleEvent;
    public GameObject[] eventQuest0;
    public GameObject[] encounterEvent;
    

    /*  Events par catégorie.
        - StartGame
            fonction du vaisseau
            affichage d'un message de bienvenu
        - Mort du vaisseau
            game over + retry
        - Mort de l'enemy
            récompense. + rien
        - Escape
            fin du combat
            destroy de l'enemy
            rien
        - nouvel event random
            event simple
            event quête // array avec tous les prefab.
            event rencontre.
            event magasin. // shop en standAlone.    
    */


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InstStartGameEvent()
    {
        Instantiate(startGameEvent);
    }

    public void InstEnemyDeathEvent()
    {
        GameObject instObj =  Instantiate(enemyDeathEvent);
        instObj.GetComponent<EventPanelScript>().eventTriggerManager = GetComponent<EventTriggerManager>();

    }
    public void InstStandardEvent()
    {
        // est-ce un event normal ou un combat ?
        // si event normal > affichage event normal
        ShowEnemyEncounterEvent();

    }

    public void ShowBasicEvent()
    {

    }
    public void ShowEnemyEncounterEvent()
    {
        if(encounterEvent.Length <= 0)
        {
            return;
        }
        int randomInt = Random.Range(0, encounterEvent.Length);
        GameObject instObj = Instantiate(encounterEvent[randomInt]);
        instObj.GetComponent<EventPanelScript>().eventTriggerManager = GetComponent<EventTriggerManager>();
    }


















}
