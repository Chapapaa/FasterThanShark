using UnityEngine;
using System.Collections;

public class Item
{
    public int itemID = 0;
    public string itemName = "ItemName";
    public string itemDescription = "blablabla";
    public itemTypeEnum itemType = itemTypeEnum.Other;
    public float baseItemCD = 0f;
    public float itemCD = 0f;
    public float itemCurrentCD = 0f;
    public int itemPwrCost = 0;
    public int itemDamage = 0;
    public int itemPrice = 0;

    public GameObject displayPanelInventory;
    public GameObject displayPanelWeapon;

    public Item(int _itemID, string _itemName, itemTypeEnum _itemType, float _itemCD, int _itemPower, int _itemDamage, int _itemPrice)
    {
        itemID = _itemID;
        itemName = _itemName;
        itemType = _itemType;
        itemCD = _itemCD;
        baseItemCD = _itemCD;
        itemPwrCost = _itemPower;
        itemDamage = _itemDamage;
        itemPrice = _itemPrice;
    }

    public enum itemTypeEnum
    {
        Weapon,
        Other
    };


}
