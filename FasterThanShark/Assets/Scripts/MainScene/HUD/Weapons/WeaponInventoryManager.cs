using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class WeaponInventoryManager : MonoBehaviour {

    public GameObject descriptionPanel;
    public GameObject îtemPanel;
    public GameObject equippedPanel;
    public GameObject unequippedPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddWeaponInEquipped(Item _item)
    {
        GameObject instObj = Instantiate(îtemPanel);
        instObj.transform.SetParent(equippedPanel.transform);
        _item.displayPanelWeapon = instObj;
        ItemPanelDisplay itemPnlDis = instObj.GetComponent<ItemPanelDisplay>();
        itemPnlDis.itemName.GetComponent<Text>().text = _item.itemName;
        itemPnlDis.itemPower.GetComponent<Image>().fillAmount = _item.itemPwrCost / 10f;
        itemPnlDis.isEquipped = true;
        itemPnlDis.descriptionPanel = descriptionPanel;
        itemPnlDis.item = _item;
    }
    public void RemoveWeaponEquipped(GameObject _itemPanel)
    {
        for(int i = 0; i < equippedPanel.transform.childCount; i++ )
        {
            GameObject child = equippedPanel.transform.GetChild(i).gameObject;
            if (child == _itemPanel)
            {
                Destroy(child);
            }
        }
    }
    public void AddWeaponInUnequipped(Item _item)
    {

        GameObject instObj = Instantiate(îtemPanel);
        instObj.transform.SetParent(unequippedPanel.transform);
        _item.displayPanelInventory = instObj;
        ItemPanelDisplay itemPnlDis = instObj.GetComponent<ItemPanelDisplay>();
        itemPnlDis.itemName.GetComponent<Text>().text = _item.itemName;
        itemPnlDis.itemPower.GetComponent<Image>().fillAmount = _item.itemPwrCost / 10f;
        itemPnlDis.isEquipped = false;
        itemPnlDis.descriptionPanel = descriptionPanel;
        itemPnlDis.item = _item;

    }
    public void RemoveWeaponUnequipped(GameObject _itemPanel)
    {
        for (int i = 0; i < unequippedPanel.transform.childCount; i++)
        {
            GameObject child = unequippedPanel.transform.GetChild(i).gameObject;
            if (child == _itemPanel)
            {
                Destroy(child);
            }
        }
    }






}
