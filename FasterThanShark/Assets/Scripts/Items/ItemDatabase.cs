using UnityEngine;
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
        // ID | Name | Type | CoolDown | Damage | Price
        itemDatabase.Add(new Item(0,"defaultItem", Item.itemTypeEnum.Other, 0f, 0, 0));
        itemDatabase.Add(new Item(1,"TestCannon1", Item.itemTypeEnum.Weapon, 2f, 1, 0));
        itemDatabase.Add(new Item(2, "TestCannon2", Item.itemTypeEnum.Weapon, 5f, 2, 0));
    }
    public Item GetItem(int ID)
    {
        foreach (var x in itemDatabase)
        {
            if(x.itemID == ID )
            {
                return new Item(x.itemID, x.itemName,x.itemType,x.itemCD,x.itemDamage,x.itemPrice);
            }
        }
        return null;
    }
}
