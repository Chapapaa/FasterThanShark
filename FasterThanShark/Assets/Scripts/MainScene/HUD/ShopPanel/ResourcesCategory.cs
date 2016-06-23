using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ResourcesCategory : MonoBehaviour , IPointerEnterHandler{

    public GameObject descriptionPanel;

    public PlayerStats playerSats;
    public Text numberResTxt;
    public Text priceResTxt;

    public int numberOfResources = 10;
    public int priceOfResources = 10;
    public ResourceType resource;

    string resourceDesc;
    string resourceTitle;

    DescriptionManager descMng;


    // Use this for initialization
    void Start () {
        descMng = descriptionPanel.GetComponent<DescriptionManager>();


    }
	
	// Update is called once per frame
	void Update ()
    {
        numberResTxt.text = numberOfResources.ToString();
        priceResTxt.text = priceOfResources.ToString();

        if (playerSats.gold >= priceOfResources && numberOfResources > 0)
        {
            GetComponent<Button>().image.color = Color.white;
        }
        else if (numberOfResources <= 0)
        {
            GetComponent<Button>().image.color = Color.grey;
        }
        else
        {
            GetComponent<Button>().image.color = Color.red;
        }
	
	}

    public void BuyRepair()
    {
        if (playerSats.gold >= priceOfResources && numberOfResources > 0)
        {
            if(playerSats.health1 < playerSats.maxHealth1)
            {
                BuyResource();
                playerSats.health1 += 1;
            }
        }
    }
    public void BuyFood()
    {
        if (playerSats.gold >= priceOfResources && numberOfResources > 0)
        {
           BuyResource();
            playerSats.GainFood(1);
        }

    }
    public void BuyCannonball()
    {
        if (playerSats.gold >= priceOfResources && numberOfResources > 0)
        {
            BuyResource();
            playerSats.GainCannonball(1);
        }
    }

    void BuyResource()
    {
        playerSats.LoseGold(priceOfResources);
        numberOfResources -= 1;
    }

    public enum ResourceType
    {
        repair,
        food,
        cannonball
    }


    public void OnPointerEnter(PointerEventData eventData)
    {

        initDescription();
        descMng.SetDescriptionPanel(resourceTitle, resourceDesc, priceOfResources.ToString());
    }

    void initDescription()
    {
        if(resource == ResourceType.repair)
        {
            resourceDesc = "All you need to repair your ship hull at the best price ! \n Repair your hull by 1.";
            resourceTitle = "Repair";
        }
        if(resource == ResourceType.food)
        {
            resourceDesc = "Some fresh and tasty food, essential for your journey across the oceans ! \n Add 1 food.";
            resourceTitle = "Food";
        }
        if (resource == ResourceType.cannonball)
        {
            resourceDesc = "Basic cannonball to get rid of any enemy on your way ! \n Add 1 Cannonball.";
            resourceTitle = "Ammunition";
        }

    }






}
