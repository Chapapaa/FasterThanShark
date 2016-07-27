using UnityEngine;
using System.Collections;

public class EventWindowManager : MonoBehaviour {


    public GameObject mainCamera;
    public Transform cameraCenter;
    public Transform cameraOnShip;
    public Transform battleCamera;

    public GameObject ShopButton;

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

        SetStandardCamera();
        GameObject instObj = Instantiate(startGameEvent);
    }

    public void InstEnemyDeathEvent()
    {
        SetStandardCamera();
        GameObject instObj =  Instantiate(enemyDeathEvent);
        instObj.GetComponent<EventPanelScript>().eventTriggerManager = GetComponent<EventTriggerManager>();

    }
    public void InstStandardEvent()
    {
        int random = Random.Range(0, 100);
        // events de text
        if (random < 100)     
        {
            ShowBasicEvent();
        }
        // events de combat
        else
        {
            ShowEnemyEncounterEvent();
        }
       

    }

    public void ShowBasicEvent()
    {
        
        if (simpleEvent.Length <= 0)
        {
            return;
        }
        SetStandardCamera();
        int randomInt = Random.Range(0, simpleEvent.Length);
        print(randomInt.ToString());

        GameObject instObj = Instantiate(simpleEvent[randomInt]);
        instObj.GetComponent<EventPanelScript>().eventTriggerManager = GetComponent<EventTriggerManager>();
    }
    public void ShowEnemyEncounterEvent()
    {

        if(encounterEvent.Length <= 0)
        {
            return;
        }
        SetBattleCamera();
        int randomInt = Random.Range(0, encounterEvent.Length);
        GameObject instObj = Instantiate(encounterEvent[randomInt]);
        instObj.GetComponent<EventPanelScript>().eventTriggerManager = GetComponent<EventTriggerManager>();
    }



    public void SetBattleCamera()
    {
        mainCamera.transform.position = battleCamera.position;
    }
    public void SetStandardCamera()
    {
        mainCamera.transform.position = cameraOnShip.position;
    }














}
