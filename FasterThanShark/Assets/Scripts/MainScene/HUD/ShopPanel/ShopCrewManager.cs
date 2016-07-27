using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopCrewManager : MonoBehaviour, IPointerEnterHandler {

    public CrewContentManager crewCtntMng;
    public PlayerStats playerStats;
    public Character crewMember = null;
    public GameObject descriptionPanel;
    public Text nameText;
    public Text priceText;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (crewMember != null)
        {
            nameText.text = crewMember.charName;
            priceText.text = crewMember.charPrice.ToString();
            if (playerStats.gold < crewMember.charPrice)
            {
                GetComponent<Image>().color = Color.red;
            }
            else
            {
                GetComponent<Image>().color = Color.white;
            }

        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (descriptionPanel != null && crewMember != null)
        {
            //string descTitleText = crewMember.name;
            //string descContentText = ""; //selfItem.itemDescription + "\n Damage : " + selfItem.itemDamage.ToString() + "\n Delay : " + selfItem.itemCD.ToString() + " seconds" + "\n Matelots : " + selfItem.itemPwrCost.ToString();
            //string descPriceText = crewMember.price.ToString();
            CrewShopDescription crewShopDesc = descriptionPanel.GetComponent<CrewShopDescription>();
            crewShopDesc.crew = crewMember;
            descriptionPanel.SetActive(false);
            descriptionPanel.SetActive(true);
            //crewShopDesc.crew = crewMember;
        }
    }

    public void HireCrew()
    {
        if (playerStats.gold >= crewMember.charPrice)
        {
            playerStats.LoseGold(crewMember.charPrice);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<CharSpawnManager>().SpawnAlly(crewMember.charName, crewMember.navLevel, crewMember.repairLevel, crewMember.weaponLevel, crewMember.modRepairLevel, crewMember.medicLevel);
            Destroy(gameObject);
        }
    }



}
