using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemInventory : MonoBehaviour {

    public ItemDatabase databaseSCR;
    public WeaponManager weaponSCR;
    public List<Item> playerWeaponInventory = new List<Item>();
    public List<Item> playerInventory = new List<Item>();

	// Use this for initialization
	void Start ()
    {
        playerWeaponInventory.Add(databaseSCR.GetItem(1));
        weaponSCR.RefreshWeapons();


    }

    void Update()
    {
        foreach(Item item in playerWeaponInventory)
        {
            if(item.itemCurrentCD < item.itemCD )
            {
                item.itemCurrentCD += Time.deltaTime;
            }
        }
    }

    public void AddItemToInventory(int itemID)
    {
        playerInventory.Add(databaseSCR.GetItem(itemID));
    }
    public void RemoveItemFromInventory(int itemID)
    {
        playerInventory.Remove(databaseSCR.GetItem(itemID));
    }


}
