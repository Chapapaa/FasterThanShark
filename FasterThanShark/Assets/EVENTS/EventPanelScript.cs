using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EventPanelScript : MonoBehaviour {

    public EventsMainManager eventMng;

    public Text titleText;
    public Text descText;


    // Use this for initialization
    void Start ()
    {
        PauseManager.Pause();
        //eventMng.ShowFullShip();
    }
	
	// Update is called once per frame
	void Update () {
        if(!PauseManager.isGamePaused)
        {
            PauseManager.Pause();
        }
	
	}

    public void BattleCamera()
    {
        eventMng.SetCameraPos("battle");
    }
    public void CenterCamera()
    {
        eventMng.SetCameraPos("standard"); 
    }
    public void ShipCamera()
    {
        eventMng.SetCameraPos("ship");
    }


    public void CloseWindow()
    {
        eventMng.ShowHalfShip();
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        PauseManager.Resume();
    }

    public void SetTitle(string _title)
    {
        titleText.text = _title;
    }
    public void SetDesc(string _desc)
    {
        descText.text = _desc;
    }
    public void SpawnEnemy(Ship.shipType _shipType)
    {
        eventMng.SpawnEnemy(_shipType);
    }
    public void SpawnEnemy(int _shipID)
    {
        eventMng.SpawnEnemy(_shipID);
    }
    public void DispawnEnemy()
    {
        eventMng.DispawnEnemy();
    }
    public void ClaimReward(int golds, int food, int cnb, int weaponID)
    {
        eventMng.SetReward(golds, food, cnb, weaponID);
        eventMng.ClaimReward();
    }




}
