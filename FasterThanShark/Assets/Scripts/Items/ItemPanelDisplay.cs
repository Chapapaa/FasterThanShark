using UnityEngine;
using System.Collections;

public class ItemPanelDisplay : MonoBehaviour {

    ItemInventory inventory;
    public GameObject itemName;
    public GameObject itemDescription;
    public GameObject itemPower;


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
}
