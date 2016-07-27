using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StandardEvent01 : MonoBehaviour {

    public GameObject closeButton;
    public GameObject descriptionPanel0;
    public GameObject choicePrefab;
    public GameObject choicesPanelContainer;



	// Use this for initialization
	void Start () {
        InstanciateChoice(0, "Explore !");
        InstanciateChoice(1, "Leave");
        closeButton.SetActive(false);



    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DoSomothing(int index)
    {
        if ( index == 0)
        {
            ClearChoices();
            string desc2 = "This island doesn't contain anything particular.\nYou gather some food";
            descriptionPanel0.GetComponent<Text>().text = desc2;
            closeButton.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().GainFood(5);


        }
        if (index == 1)
        {
            ClearChoices();
            string desc2 = "You leave immediatly and continue your journey";
            descriptionPanel0.GetComponent<Text>().text = desc2;
            closeButton.SetActive(true);
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
        for(int i = 0; i < choicesPanelContainer.transform.childCount; i++)
        {
            Destroy(choicesPanelContainer.transform.GetChild(i).gameObject);
        }
    }




}
