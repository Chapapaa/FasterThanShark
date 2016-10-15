using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponSellManager : MonoBehaviour {

    public ShopSellManager shopMng;
    public Item weaponItem = null;
    public Text nameText;
    public Text priceText;

    public GameObject confirmPanel;

	// Use this for initialization
	void Start () {
        if(weaponItem != null)
        {
            nameText.text = weaponItem.itemName;
            priceText.text = weaponItem.itemPrice.ToString();
        }
	
	}

    public void SellWeapon()
    {
        confirmPanel.SetActive(true);
        // affiche un panel de verification (Sell for : value ? Yes/no en button
        // qui appelle confirmSell();

    }
    public void ConfirmSell()
    {
        shopMng.SellWeapon(weaponItem);
    }




    // Update is called once per frame
    void Update () {
	
	}
}
