using UnityEngine;
using System.Collections;

public class EventPanelScript : MonoBehaviour {

    public EventTriggerManager eventTriggerManager;


	// Use this for initialization
	void Start () {
        PauseManager.Pause();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseWindow()
    {
        PauseManager.Resume();
        Destroy(gameObject);
    }

}
