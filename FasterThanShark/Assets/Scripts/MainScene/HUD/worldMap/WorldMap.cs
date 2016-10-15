using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WorldMap : MonoBehaviour {

    public EventsDatabase database;
    public EventsMainManager eventsMng;

    int eventID = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public void CallEvent(int _id)
    {
        eventID = _id;
        MoveToEvent();
    }

    public void MoveToEvent()
    {
        eventsMng.ShowEvent(eventID);
        eventsMng.difficulty += 1;
    }

}
