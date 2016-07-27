using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class ItemPanelDisplay : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler  {

    ItemInventory inventory;
    public Item item;
    public GameObject descriptionPanel;
    public GameObject itemName;
    public GameObject itemDescription;
    public GameObject itemPower;
    public bool isEquipped = false;


    // Use this for initialization
    void Start ()
    {
        inventory = GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemInventory>();
    }

    public void UnEquipItem()
    {
        inventory.UnEquipItem(gameObject);
    }
    public void EquipItem()
    {
        inventory.EquipItem(gameObject);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isEquipped)
        {
            UnEquipItem();
        }
        else
        {
            EquipItem();
        }
    }
    public void DeleteItem()
    {
        if(isEquipped)
        {
            UnEquipItem();
        }
        else
        {
            inventory.RemoveItemFromInventory(item);
        }
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.GetComponent<WeaponDescriptionManager>().item = item;
        descriptionPanel.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }
}
