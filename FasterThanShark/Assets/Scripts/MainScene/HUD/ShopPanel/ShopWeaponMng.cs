using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ShopWeaponMng : MonoBehaviour, IPointerEnterHandler {

    public WeaponContentManager wpnCtntMng;
    public PlayerStats playerStats;

    public Item selfItem;
    public GameObject descriptionPanel;
    public Text nameText;
    public Text priceText;

	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	

	}
	
	// Update is called once per frame
	void Update ()
    {
        if(selfItem != null)
        {
            nameText.text = selfItem.itemName;
            priceText.text = selfItem.itemPrice.ToString();
        }
        // playerStats // Si pas assez de golds change le couleur 

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(descriptionPanel != null && selfItem != null)
        {
            string descTitleText = selfItem.itemName;
            string descContentText = selfItem.itemDescription + "\n Damage : " + selfItem.itemDamage.ToString() + "\n Delay : " + selfItem.itemCD.ToString() + " seconds" + "\n Matelots : " + selfItem.itemPwrCost.ToString();
            string descPriceText = selfItem.itemPrice.ToString();

            descriptionPanel.GetComponent<DescriptionManager>().SetDescriptionPanel(descTitleText, descContentText, descPriceText);
        }
    }

    public void BuyWeapon()
    {
        if(playerStats.gold >= selfItem.itemPrice)
        {
            playerStats.LoseGold(selfItem.itemPrice);
            wpnCtntMng.BuyWeapon(selfItem.itemID);
            Destroy(gameObject);
        }
    }
}
