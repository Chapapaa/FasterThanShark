using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeathEvent : MonoBehaviour {


    public GameObject rewardPanel;
    public EventPanelScript eventScript;
    public int GoldRewardAmount = 50;

	// Use this for initialization
	void Start () {
        ShowReward();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowReward()
    {
        // td : initialise la reward

        rewardPanel.SetActive(true);
    }

    public void GetReward()
    {
        eventScript.eventTriggerManager.GetReward(GoldRewardAmount);
    }

}
