using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponButtonDisplay : MonoBehaviour
{

    public ItemInventory inventorySCR;

    public Transform[] weaponSlots;


    public void RefreshDisplay()
    {
        for (int i = 0; i < 4; i++)
        {
            weaponSlots[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < inventorySCR.playerWeaponInventory.Count; i++)
        {
            GameObject buttonObject = weaponSlots[i].gameObject;
            buttonObject.GetComponent<WeaponHudButtonDisplayMng>().Initialize(inventorySCR.playerWeaponInventory[i]);
            //buttonObject.GetComponentInChildren<Text>().text = inventorySCR.playerWeaponInventory[i].itemName;
            buttonObject.SetActive(true);
        }
    }
}
