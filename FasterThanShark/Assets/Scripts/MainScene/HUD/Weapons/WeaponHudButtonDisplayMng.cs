using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WeaponHudButtonDisplayMng : MonoBehaviour, IPointerDownHandler {

    //public ItemInventory inventory;
    public GameObject powerImage;
    public GameObject weaponCharge;
    public GameObject itemName;
    public int weaponIndex;
    Item itemInUse;
    WeaponManager weaponMng;


    public void Initialize(Item item)
    {
        itemInUse = item;
        powerImage.GetComponent<Image>().fillAmount = item.itemPwrCost / 10f;
        itemName.GetComponent<Text>().text = item.itemName;
    }

	// Use this for initialization
	void Start ()
    {
        weaponMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<WeaponManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (itemInUse != null)
        {
            weaponCharge.GetComponent<Image>().fillAmount = itemInUse.itemCurrentCD / itemInUse.itemCD;
        }
        if(weaponMng.weapons[weaponIndex].weaponPwr > 0)
        {
            powerImage.GetComponent<Image>().color = Color.green;
        }
        else
        {
            powerImage.GetComponent<Image>().color = Color.grey;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            weaponMng.SelectWeapon(weaponIndex);
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            weaponMng.UnPowerWeapon(weaponIndex);
        }
    }
}
