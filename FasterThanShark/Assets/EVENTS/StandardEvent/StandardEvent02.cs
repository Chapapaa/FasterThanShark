using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StandardEvent02 : MonoBehaviour
{

    public GameObject closeButton;
    public GameObject descriptionPanel0;
    public GameObject choicePrefab;
    public GameObject choicesPanelContainer;



    // Use this for initialization
    void Start()
    {
        InstanciateChoice(0, "Yes.");
        InstanciateChoice(1, "No, leave immediatly !");
        closeButton.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DoSomothing(int index)
    {
        
        if (index == 0)
        {
            ClearChoices();
            int randomInt = Random.Range(0, 100);
            if(randomInt < 30)
            {
                string desc2 = "It's a pirate ship !\n They arm the cannons !";
                descriptionPanel0.GetComponent<Text>().text = desc2;
                InstanciateChoice(2, "Prepare to fight !");
                InstanciateChoice(3, "Try to leave before they get closer.");
            }
            else
            {
                string desc2 = "It looks like a merchant ship, they are leaving the island.";
                descriptionPanel0.GetComponent<Text>().text = desc2;
                InstanciateChoice(2, "Attack the ship !");
                InstanciateChoice(4, "Let it go and explore the city.");
            }
        }
        if (index == 1)
        {
            ClearChoices();
            string desc2 = "You leave immediatly and continue your journey";
            descriptionPanel0.GetComponent<Text>().text = desc2;
            closeButton.SetActive(true);
        }
        if (index == 2)
        {
            GetComponent<EventPanelScript>().eventTriggerManager.StartBattle(0);
            Destroy(gameObject);
               
            //ClearChoices();
            //string desc2 = "You leave immediatly and continue your journey";
            //descriptionPanel0.GetComponent<Text>().text = desc2;
            //closeButton.SetActive(true);
        }
        if (index == 3)
        {
            ClearChoices();
            int randomInt = Random.Range(0, 100);
            if (randomInt < 30)
            {
                string desc2 = "They are too fast we can't escape  !";
                descriptionPanel0.GetComponent<Text>().text = desc2;
                InstanciateChoice(2, "Arm the cannons !");
            }
            else
            {
                string desc2 = "You succeed to escape...";
                descriptionPanel0.GetComponent<Text>().text = desc2;
                closeButton.SetActive(true);
            }
        }
        if(index == 4)
        {

            GetComponent<EventPanelScript>().eventTriggerManager.ShowShop();
            Destroy(gameObject);
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
