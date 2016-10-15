using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponDelManager : MonoBehaviour {

    public FullInventoryManager fullInvMng;
    public Text nameText;
    public Text priceText;
    public int weaponID;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetName(string _name)
    {
        nameText.text = _name;
    }
    public void SetPrice(int price)
    {
        priceText.text = price.ToString();
    }

    public void ConfirmDelete()
    {
        fullInvMng.DeleteItem(weaponID);
    }

}
