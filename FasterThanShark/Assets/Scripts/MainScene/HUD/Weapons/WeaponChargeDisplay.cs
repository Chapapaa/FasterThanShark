using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponChargeDisplay : MonoBehaviour {

    public ItemInventory inventorySCR;
    public int itemIndex = 0;
    float fill = 0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(inventorySCR.playerWeaponInventory.Count > itemIndex)
        {
            fill = inventorySCR.playerWeaponInventory[itemIndex].itemCurrentCD / inventorySCR.playerWeaponInventory[itemIndex].itemCD;
            GetComponent<Image>().fillAmount = fill;
        }
        


    }
}
