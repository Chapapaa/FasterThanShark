using UnityEngine;
using System.Collections;

public class EventPanelScript : MonoBehaviour {

    public EventTriggerManager eventTriggerManager;

    ShipManager shipMng;

    // Use this for initialization
    void Start () {

        PauseManager.Pause();
        shipMng = GameObject.FindGameObjectWithTag("MainShip").GetComponent<ShipManager>();
        shipMng.ShowFullShip();
        


    }
	
	// Update is called once per frame
	void Update () {
        if(!PauseManager.isGamePaused)
        {
            PauseManager.Pause();
        }
	
	}

    public void CloseWindow()
    {
        PauseManager.Resume();
        shipMng.ShowHalfShip();
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        PauseManager.Resume();
    }



}
