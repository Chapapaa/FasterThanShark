using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyDeathEvent : MonoBehaviour {

    public GameObject rewardPrefab;
    public GameObject choicePrefab;
    public GameObject choicesPanelContainer;

    EventPanelScript evntPanelScr;
    EventsMainManager eventManager;


    int golds = 0;
    int food = 0;
    int cannonball = 0;
    int weaponID = -1;

    // Use this for initialization
    void Start()
    {
        
        evntPanelScr = GetComponent<EventPanelScript>();
        eventManager = evntPanelScr.eventMng;
        golds = eventManager.goldReward;
        food = eventManager.foodReward;
        cannonball = eventManager.cannonballReward;
        if(eventManager.itemReward != null)
        {
            weaponID = eventManager.itemReward.itemID;
        }
        evntPanelScr.ShipCamera();
        evntPanelScr.SetTitle("Enemy destroyed");
        evntPanelScr.SetDesc("You destroyed your opponent and you collect some resources !");
        InstanciateReward(golds, food, cannonball, weaponID);
        InstanciateChoice(0, "Close");
        //GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemInventory>().AddItemToInventory(3);


    }
    public void DoSomothing(int index)
    {
        ClearChoices();
        
        if (index == 0)
        {
            //evntPanelScr.ClaimReward(golds, food, cannonball, weaponID); // déjà claim par le mainEventManager;
            evntPanelScr.CloseWindow();
        }
        else if (index == -1)
        {
            evntPanelScr.CloseWindow();
        }

    }
    public void InstanciateChoice(int indexOfChoice, string buttonText)
    {
        GameObject instObj = Instantiate(choicePrefab);
        instObj.transform.SetParent(choicesPanelContainer.transform);
        instObj.transform.localScale = Vector3.one;
        ChoicePrefab choicePrefb = instObj.GetComponent<ChoicePrefab>();
        choicePrefb.CallBackFunction = DoSomothing;
        choicePrefb.index = indexOfChoice;
        choicePrefb.index = indexOfChoice;
        choicePrefb.myText = buttonText;
    }
    public void InstanciateReward(int golds, int food, int cnb, int weaponID)
    {
        GameObject instObj = Instantiate(rewardPrefab);
        instObj.transform.SetParent(choicesPanelContainer.transform);
        instObj.transform.localScale = Vector3.one;
        RewardPrefab rewardPrefb = instObj.GetComponent<RewardPrefab>();
        rewardPrefb.ShowResources(golds, food, cnb, weaponID);
    }

    void ClearChoices()
    {
        for (int i = 0; i < choicesPanelContainer.transform.childCount; i++)
        {
            Destroy(choicesPanelContainer.transform.GetChild(i).gameObject);
        }
    }
    /*
    public Text rewardText;
    public EventPanelScript eventScript;

	// Use this for initialization
	void Start () {
        EventsMainManager eventManager = eventScript.eventMng;
        ShowReward(eventManager.goldReward, eventManager.foodReward, eventManager.cannonballReward, eventManager.itemReward);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowReward(int _golds, int _food, int _cannonball, Item _item)
    {
        string itemName = "";
        // td : initialise la reward
        if(_item != null)
        {
            itemName = _item.itemName;
        }
        rewardText.text = "Golds : " + _golds.ToString() + ", Food : " + _food.ToString() + ", Cannonball : " + _cannonball.ToString() + ", Item : " + itemName;
    }

    public void GetReward()
    {
        //eventScript.eventTriggerManager.GetReward(GoldRewardAmount);
    }
    */
}
