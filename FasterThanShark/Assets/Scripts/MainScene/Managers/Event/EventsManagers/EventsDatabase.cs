using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventsDatabase : MonoBehaviour
{

    public GameObject startGameEvent;
    public GameObject shipDeathEvent;
    public GameObject enemyDeathEvent;
    public GameObject escapeEvent;


    public GameObject shopEvent;

    public GameObject event001;
    public GameObject event002;

    public List<Game_Event> gameEvents = new List<Game_Event>();

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

    void Start()
    {
        gameEvents.Add(new Game_Event(000, Game_Event.eventType.StartGame, startGameEvent));
        gameEvents.Add(new Game_Event(010, Game_Event.eventType.ShipDeath, shipDeathEvent));
        gameEvents.Add(new Game_Event(020, Game_Event.eventType.EnemyDeath, enemyDeathEvent));
        gameEvents.Add(new Game_Event(030, Game_Event.eventType.Escape, escapeEvent));
        gameEvents.Add(new Game_Event(040, Game_Event.eventType.Shop, shopEvent));
        gameEvents.Add(new Game_Event(100, Game_Event.eventType.Standard, event001));
        gameEvents.Add(new Game_Event(101, Game_Event.eventType.Standard, event002));

    }


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
                int rdm = Random.Range(100, 101);
                return GetEvent(rdm);

            case eventType.Quest:
                return null;

            case eventType.Encounter:
                return null;

            default:
                return null;
        }
    }

    public GameObject GetEvent(int eventId)
    {
        foreach(Game_Event myEvent in gameEvents)
        {
            if(myEvent.eventId == eventId)
            {
                return myEvent.eventGO;
            }
        }
        return null;
    }
}

// TD Quests Events;