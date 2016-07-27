using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WeaponContentManager : MonoBehaviour
{

    public ItemDatabase itemDatabase;
    public ItemInventory inventory;


    public GameObject itemContainer;
    public GameObject descriptionPanel;
    public GameObject shopWeaponPrefab;
    public Item[] itemsToSpawn = new Item [10];



	// Use this for initialization
	void Start () {
        itemsToSpawn[0] = itemDatabase.GetItem(3);
        itemsToSpawn[1] = itemDatabase.GetItem(4);
        itemsToSpawn[2] = itemDatabase.GetItem(5);

        SpawnWeapons();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnWeapons()
    {
        foreach (Item item in itemsToSpawn)
        {
            if(item != null)
            {
                GameObject instWeapon = Instantiate(shopWeaponPrefab);
                instWeapon.transform.SetParent(itemContainer.transform);
                ShopWeaponMng wpnMng = instWeapon.GetComponent<ShopWeaponMng>();
                wpnMng.wpnCtntMng = GetComponent<WeaponContentManager>();
                wpnMng.descriptionPanel = descriptionPanel;
                wpnMng.selfItem = item;
            }
        }
    }

    public void BuyWeapon(int itemID)
    {
        inventory.AddItemToInventory(itemID);
    }

}
