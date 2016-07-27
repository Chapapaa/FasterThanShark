using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponDescriptionManager : MonoBehaviour {


    public Item item = null;

    public Text itemName;
    public Image itemIcon;
    public Text itemDmg;
    public Text itemCD;
    public Text ItemPwr;
    public Text itemDesc;
    public Text itemPrice; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnEnable()
    {
        if(item != null)
        {
            itemName.text = item.itemName;
            // icon
            itemDmg.text = item.itemDamage.ToString();
            itemCD.text = item.itemCD.ToString();
            ItemPwr.text = item.itemPwrCost.ToString();
            itemDesc.text = item.itemDescription;
            itemPrice.text = item.itemPrice.ToString();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
