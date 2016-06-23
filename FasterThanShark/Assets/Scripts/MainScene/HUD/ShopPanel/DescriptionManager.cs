using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour {

    public Text titleTxt;
    public Text descTxt;
    public Text priceTxt;


	// Use this for initialization
	void Start () {
        titleTxt.text = "";
        descTxt.text = "";
        priceTxt.text = "";

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetDescriptionPanel(string title, string description, string price)
    {
        titleTxt.text = title;
        descTxt.text = description;
        priceTxt.text = "Price : " + price + "G";

    }
}
