using UnityEngine;
using System.Collections;

public class Game_Event {

    public int eventId = -1;
    public eventType type;
    public GameObject eventGO;


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


    public Game_Event(int _eventId, eventType _type, GameObject _eventGO)
    {
        eventId = _eventId;
        type = _type;
        eventGO = _eventGO;
    }


}
