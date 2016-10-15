using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopSellManager : MonoBehaviour {

    public GameObject weaponContainer;
    public GameObject resourceContainer;

    public ItemInventory itemInventory;
    public PlayerStats playerStats;

    public GameObject resourcePrefab;
    public GameObject weaponPrefab;

    int food = 0;
    int foodPrice = 10;
    int cannonball = 0;
    int cannonballPrice = 20;
    List<Item> eqpWeapons;
    List<Item> uneqpWeapons;


    // Use this for initialization
    void Start () {
	
	}

    void OnEnable()
    {
        
        RefreshDisplays();
        
        // cree un prefab par ressource
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void RefreshDisplays()
    {
        ClearContainers();
        eqpWeapons = itemInventory.playerWeaponInventory;
        uneqpWeapons = itemInventory.playerInventory;
        food = playerStats.food;
        cannonball = playerStats.cannonball;
        if (food > 0)
        {
            GameObject instObj1 = Instantiate(resourcePrefab);
            instObj1.transform.SetParent(resourceContainer.transform);
            ResourceSellManager foodRSM = instObj1.GetComponent<ResourceSellManager>();
            foodRSM.shopMng = this;
            foodRSM.SetName("Food");
            foodRSM.SetPrice(foodPrice);
        }
        if (cannonball > 0)
        {
            GameObject instObj2 = Instantiate(resourcePrefab);
            instObj2.transform.SetParent(resourceContainer.transform);
            ResourceSellManager cannonballRSM = instObj2.GetComponent<ResourceSellManager>();
            cannonballRSM.shopMng = this;
            cannonballRSM.SetName("Cannonball");
            cannonballRSM.SetPrice(cannonballPrice);
        }
        foreach (Item weapon in eqpWeapons)
        {
            GameObject instObj3 = Instantiate(weaponPrefab);
            instObj3.transform.SetParent(weaponContainer.transform);
            WeaponSellManager weapon1WSM = instObj3.GetComponent<WeaponSellManager>();
            weapon1WSM.shopMng = this;
            weapon1WSM.weaponItem = weapon;
        }
        foreach (Item weapon2 in uneqpWeapons)
        {
            GameObject instObj4 = Instantiate(weaponPrefab);
            instObj4.transform.SetParent(weaponContainer.transform);
            WeaponSellManager weapon2WSM = instObj4.GetComponent<WeaponSellManager>();
            weapon2WSM.shopMng = this;
            weapon2WSM.weaponItem = weapon2;
        }
    }



    public void ClearContainers()
    {
        RectTransform[] childs = weaponContainer.GetComponentsInChildren<RectTransform>();
        foreach (RectTransform panel in childs)
        {
            if(panel.gameObject != weaponContainer.gameObject)
            {
                Destroy(panel.gameObject);
            }
        }
        RectTransform[] childs2 = resourceContainer.GetComponentsInChildren<RectTransform>();
        foreach (RectTransform panel in childs2)
        {
            if (panel.gameObject != resourceContainer.gameObject)
            {
                Destroy(panel.gameObject);
            }
        }
    }

    public void SellResource(string _name)
    {
        if(_name == "Food")
        {
            playerStats.LoseFood(1);
            playerStats.GainGold(foodPrice);
        }
        else if(_name == "Cannonball")
        {
            playerStats.LoseCannonball(1);
            playerStats.GainGold(cannonballPrice);
        }

        RefreshDisplays();
    }

    public void SellWeapon(Item weapon)
    {
        playerStats.GainGold(weapon.itemPrice);
        itemInventory.DeleteItem(weapon.itemID);
        RefreshDisplays();

    }



}
