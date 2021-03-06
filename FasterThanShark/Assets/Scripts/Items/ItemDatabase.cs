﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {

    List<Item> itemDatabase = new List<Item>();

	// Use this for initialization
	void Start ()
    {
        Initialisation();


    }

    void Initialisation()
    {
        // ID | Name | Type | CoolDown | Power | Damage | Price
        itemDatabase.Add(new Item(0,"defaultItem", Item.itemTypeEnum.Other, 0f, 0, 0, 0));
        itemDatabase.Add(new Item(1,"TestCannon1", Item.itemTypeEnum.Weapon, 2f,1, 1, 50));
        itemDatabase.Add(new Item(2, "TestCannon2", Item.itemTypeEnum.Weapon, 5f, 2, 2, 60));
        itemDatabase.Add(new Item(3, "Cannon", Item.itemTypeEnum.Weapon, 2f, 1, 1, 50));
        itemDatabase.Add(new Item(4, "Cannon II", Item.itemTypeEnum.Weapon, 3f, 2, 2, 80));
        itemDatabase.Add(new Item(5, "Mega Cannon", Item.itemTypeEnum.Weapon, 6f, 3, 5, 120));
    }
    public Item GetItem(int ID)
    {
        foreach (var x in itemDatabase)
        {
            if(x.itemID == ID )
            {
                return new Item(x.itemID, x.itemName,x.itemType,x.itemCD,x.itemPwrCost,x.itemDamage,x.itemPrice);
            }
        }
        return null;
    }
}
