using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StandardEvent01 : MonoBehaviour {
    public GameObject rewardPrefab;
    public GameObject choicePrefab;
    public GameObject choicesPanelContainer;

    EventPanelScript evntPanelScr;

    int golds = 0;
    int food = 0;
    int cannonball = 0;
    int weaponID = -1; 



    // Use this for initialization
    void Start()
    {
        evntPanelScr = GetComponent<EventPanelScript>();
        evntPanelScr.ShipCamera();
        evntPanelScr.SetTitle("Island in sight !");
        evntPanelScr.SetDesc("It looks like a little forest-covered island ! \nShould we explore it ?");
        InstanciateChoice(0, "Yes");
        InstanciateChoice(1, "No");
        //GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemInventory>().AddItemToInventory(3);


    }
    public void DoSomothing(int index)
    {
        ClearChoices();
        if (index == 0)
        {
            evntPanelScr.SetDesc("You only find some food to gather");
            food = Random.Range(1, 6);
            /**/
            InstanciateReward(golds, food, cannonball, weaponID);
            InstanciateChoice(2, "Close");
        }
        else if (index == 1)
        {
            evntPanelScr.SetDesc("You leave immediatly and continue your journey");
            InstanciateChoice(-1, "Close");
        }
        else if (index == 2)
        {
            evntPanelScr.ClaimReward(golds, food, cannonball, weaponID);
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

}
