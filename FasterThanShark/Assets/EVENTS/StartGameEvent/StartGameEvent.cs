using UnityEngine;
using System.Collections;

public class StartGameEvent : MonoBehaviour {

    public GameObject choicePrefab;
    public GameObject choicesPanelContainer;

    EventPanelScript evntPanelScr;

    // Use this for initialization
    void Start () {
        evntPanelScr = GetComponent<EventPanelScript>();
        evntPanelScr.ShipCamera();
        evntPanelScr.SetTitle("A new journey begins");
        evntPanelScr.SetDesc("Hi Captain.\n\nWe are ready to conquer the ocean !");
        InstanciateChoice(-1, "Close");
        //GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemInventory>().AddItemToInventory(3);


    }
    public void DoSomothing(int index)
    {
        ClearChoices();
        if (index == -1)
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

    void ClearChoices()
    {
        for (int i = 0; i < choicesPanelContainer.transform.childCount; i++)
        {
            Destroy(choicesPanelContainer.transform.GetChild(i).gameObject);
        }
    }
}