using UnityEngine;
using System.Collections;

public class EventsDatabase : MonoBehaviour {

    public GameObject startGameEvent;
    public GameObject shipDeathEvent;
    public GameObject enemyDeathEvent;
    public GameObject escapeEvent;

    public GameObject shopEvent;

    public GameObject[] simpleEvent;
    public GameObject[] eventQuest0;
    public GameObject[] encounterEvent;

    public enum eventType
    {
        StartGame, 
        ShipDeath,
        EnemyDeath,
        Escape,
        Shop,
        Standard,
        Quest,
        Encounter
    };


    public GameObject GetEvent(eventType eventType)
    {
        switch (eventType)
        {
            case eventType.StartGame:
                return startGameEvent;

            case eventType.ShipDeath:
                return shipDeathEvent;

            case eventType.EnemyDeath:
                return enemyDeathEvent;

            case eventType.Escape:
                return escapeEvent;

            case eventType.Shop:
                return shopEvent;

            case eventType.Standard:
                int rdm = Random.Range(0, simpleEvent.Length);
                return simpleEvent[rdm];

            case eventType.Quest:
                return eventQuest0[0];

            case eventType.Encounter:
                int rdm2 = Random.Range(0, encounterEvent.Length);
                return simpleEvent[rdm2];

            default:
                return null;
        }
    }
}

// TD Quests Events;