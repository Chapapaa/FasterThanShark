using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FullInventoryManager : MonoBehaviour {

    public GameObject weaponPrefab;
    public GameObject inventoryContainer;
    public GameObject newWeaponContainer;
    public ItemInventory inventorySCR;
    public Item tempItem;




	void OnEnable()
    {
        PauseManager.Pause();
        if (tempItem != null)
        {
            RefreshDisplays();
        }

    }

    void RefreshDisplays()
    {
        if (tempItem != null)
        {
            ClearContainers();
            List<Item> equipedWeapons = inventorySCR.playerWeaponInventory;
            List<Item> unEquipedWeapons = inventorySCR.playerInventory;
            foreach (Item item in equipedWeapons)
            {
                GameObject instObj1 = Instantiate(weaponPrefab);
                instObj1.transform.SetParent(inventoryContainer.transform);
                WeaponDelManager weaponDelMng1 = instObj1.GetComponent<WeaponDelManager>();
                weaponDelMng1.fullInvMng = this;
                weaponDelMng1.SetName(item.itemName);
                weaponDelMng1.SetPrice(item.itemPrice);
                weaponDelMng1.weaponID = item.itemID;
            }
            foreach (Item item2 in unEquipedWeapons)
            {
                GameObject instObj2 = Instantiate(weaponPrefab);
                instObj2.transform.SetParent(inventoryContainer.transform);
                WeaponDelManager weaponDelMng2 = instObj2.GetComponent<WeaponDelManager>();
                weaponDelMng2.fullInvMng = this;
                weaponDelMng2.SetName(item2.itemName);
                weaponDelMng2.SetPrice(item2.itemPrice);
                weaponDelMng2.weaponID = item2.itemID;
            }
            GameObject instObj3 = Instantiate(weaponPrefab);
            instObj3.transform.SetParent(newWeaponContainer.transform);
            WeaponDelManager weaponDelMng3 = instObj3.GetComponent<WeaponDelManager>();
            weaponDelMng3.fullInvMng = this;
            weaponDelMng3.SetName(tempItem.itemName);
            weaponDelMng3.SetPrice(tempItem.itemPrice);
            weaponDelMng3.weaponID = tempItem.itemID;
        }
    }

    public void DeleteItem(int _itemID)
    {
        inventorySCR.DeleteItem(_itemID);
        RefreshDisplays();
        inventorySCR.AddItemToInventory(_itemID);
        gameObject.SetActive(false);
    }

    void ClearContainers()
    {
        foreach(RectTransform child in inventoryContainer.GetComponentsInChildren<RectTransform>())
        {
            if(child.gameObject != inventoryContainer)
            {
                Destroy(child.gameObject);
            }
        }
        if(newWeaponContainer.transform.childCount > 0)
        {
            Destroy(newWeaponContainer.transform.GetChild(0).gameObject);
        }
    }


}
