using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class StandardEvent02 : MonoBehaviour
{
    public GameObject choicePrefab;
    public GameObject choicesPanelContainer;

    EventPanelScript evntPanelScr;



    // Use this for initialization
    void Start()
    {
        evntPanelScr = GetComponent<EventPanelScript>();
        evntPanelScr.SetTitle("Island in sight");
        evntPanelScr.SetDesc("Captain,\n\n I see an island with a city, \n a ship is near the harbor.\n\n Should we get closer ? ");
        InstanciateChoice(0, "Yes");
        InstanciateChoice(1, "No, leave immediatly !");
    }

    public void DoSomothing(int index)
    {
        ClearChoices();
        if (index == 0)
        {
            
            int randomInt = Random.Range(0, 100);
            if(randomInt < 30)
            {
                evntPanelScr.BattleCamera();
                evntPanelScr.SpawnEnemy(Ship.shipType.pirate);
                evntPanelScr.SetDesc("It's a pirate ship !\n They arm the cannons !");
                InstanciateChoice(5, "Prepare to fight !");
                InstanciateChoice(3, "Try to leave before they get closer.");
            }
            else
            {
                evntPanelScr.BattleCamera();
                evntPanelScr.SpawnEnemy(Ship.shipType.standard);
                evntPanelScr.SetDesc("It looks like a merchant ship, they are leaving the island.");
                
                InstanciateChoice(5, "Attack the ship !");
                InstanciateChoice(4, "Let it go and explore the city.");
            }
        }
        if (index == 1)
        {
            evntPanelScr.ShipCamera();
            evntPanelScr.DispawnEnemy();
            evntPanelScr.SetDesc("You leave immediatly and continue your journey");
            InstanciateChoice(5, "Close");
        }
        if (index == 2)
        {
            evntPanelScr.BattleCamera();
            evntPanelScr.SpawnEnemy(Ship.shipType.pirate);
            evntPanelScr.SetDesc("Seeing you approach they prepare for battle");
            InstanciateChoice(5, "Prepare to fight !");
        }
        if (index == 3)
        {
            
            int randomInt = Random.Range(0, 100);
            if (randomInt < 30)
            {
                evntPanelScr.BattleCamera();
                evntPanelScr.SpawnEnemy(Ship.shipType.pirate);
                evntPanelScr.SetDesc("They are too fast we can't escape  !");
                InstanciateChoice(5, "Arm the cannons !");
            }
            else
            {
                evntPanelScr.ShipCamera();
                evntPanelScr.DispawnEnemy();
                evntPanelScr.SetDesc("You succeed to escape...");
                InstanciateChoice(5, "Close");
            }
        }
        if(index == 4)
        {
            evntPanelScr.ShipCamera();
            evntPanelScr.DispawnEnemy();
            //GetComponent<EventPanelScript>().eventTriggerManager.ShowShop();
            evntPanelScr.CloseWindow();
        }
        if(index == 5)
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
