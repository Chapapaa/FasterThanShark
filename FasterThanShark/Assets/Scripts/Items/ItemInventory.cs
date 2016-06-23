using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ItemInventory : MonoBehaviour {

    public WeaponButtonDisplay weaponHudManager;
    public ItemDatabase databaseSCR;
    public WeaponManager weaponSCR;
    public List<Item> playerWeaponInventory = new List<Item>();
    public List<Item> playerInventory = new List<Item>();

    public GameObject playerInventoryPanel;
    public GameObject playerInventoryWeaponPanel;
    public GameObject itemDisplay;

	// Use this for initialization
	void Start ()
    {
        weaponSCR.RefreshWeapons();
    }

    void Update()
    {
        
    }

    public void AddItemToInventory(int itemID)
    {
        Item newItem = databaseSCR.GetItem(itemID);
        GameObject insObj = Instantiate(itemDisplay);
        newItem.displayPanelInventory = insObj;
        insObj.GetComponent<ItemPanelDisplay>().itemName.GetComponent<Text>().text = newItem.itemName;
        insObj.GetComponent<ItemPanelDisplay>().itemPower.GetComponent<Image>().fillAmount = newItem.itemPwrCost / 10f;
        insObj.transform.SetParent(playerInventoryPanel.transform);
        playerInventory.Add(newItem);

    }
    public void RemoveItemFromInventory(Item item)
    {
        foreach (Item itemToRemove in playerInventory)
        {
            if(itemToRemove == item)
            {
                Destroy(itemToRemove.displayPanelInventory);
                playerInventory.Remove(itemToRemove);
                return;
            }
        }
    }

    public void EquipItem(GameObject itemPanel)
    {
        // Si l'inventaire d'arme n'est pas plein
        if(playerWeaponInventory.Count >= 4)
        { return; }
        // cherche l'item a equiper, et détruit d'un coté et le rajoute de l'autre
        foreach(Item item in playerInventory)
        {
            if (item.displayPanelInventory == itemPanel)
            {
                // Si ce n'est pas une arme, return
                if(item.itemType != Item.itemTypeEnum.Weapon)
                { return; }
                Destroy(item.displayPanelInventory);
                item.displayPanelInventory = null;
                AddItemToWeaponInventory(item.itemID);
                playerInventory.Remove(item);
                break;
            }
        }
        
    }
    public void UnEquipItem(GameObject itemPanel)
    {
        foreach (Item item in playerWeaponInventory)
        {
            if (item.displayPanelWeapon == itemPanel)
            {
                Destroy(item.displayPanelWeapon);
                item.displayPanelWeapon = null;
                AddItemToInventory(item.itemID);
                playerWeaponInventory.Remove(item);
                weaponHudManager.RefreshDisplay();
                weaponSCR.RefreshWeapons();
                break;
            }
        }
    }

    void AddItemToWeaponInventory(int itemID)
    {
        Item newItem = databaseSCR.GetItem(itemID);
        playerWeaponInventory.Add(newItem);
        GameObject insObj = Instantiate(itemDisplay);
        insObj.GetComponent<ItemPanelDisplay>().itemName.GetComponent<Text>().text = newItem.itemName;
        insObj.GetComponent<ItemPanelDisplay>().itemPower.GetComponent<Image>().fillAmount = newItem.itemPwrCost / 10f;
        newItem.displayPanelWeapon = insObj;
        insObj.transform.SetParent(playerInventoryWeaponPanel.transform);
        weaponHudManager.RefreshDisplay();
        weaponSCR.RefreshWeapons();

    }

}
