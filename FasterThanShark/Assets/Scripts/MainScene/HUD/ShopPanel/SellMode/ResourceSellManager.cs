using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceSellManager : MonoBehaviour {

    public ShopSellManager shopMng;

    public GameObject nameText;
    public GameObject priceText;

    string resourceName = "";


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void SetName(string _name)
    {
        nameText.GetComponent<Text>().text = _name;
        resourceName = _name;

    }
    public void SetPrice(int _price)
    {
        priceText.GetComponent<Text>().text = _price.ToString();
    }

    public void SellResource()
    {
        shopMng.SellResource(resourceName);
    }
}
