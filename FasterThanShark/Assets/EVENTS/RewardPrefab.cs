using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RewardPrefab : MonoBehaviour {

    public Image goldImg;
    public Text goldTxt;
    public Image foodImg;
    public Text foodTxt;
    public Image cannonBallImg;
    public Text cannonBallTxt;
    public Image weaponImg;
    public Text weaponTxt;

    public void ShowResources(int golds, int food, int cannonBall, int weaponID)
    {
        resetAll();
        if(golds > 0)
        {
            goldImg.gameObject.SetActive(true);
            goldTxt.text = golds.ToString();
            goldTxt.gameObject.SetActive(true);
        }
        if (food > 0)
        {
            foodImg.gameObject.SetActive(true);
            foodTxt.text = food.ToString();
            foodTxt.gameObject.SetActive(true);
        }
        if (cannonBall > 0)
        {
            cannonBallImg.gameObject.SetActive(true);
            cannonBallTxt.text = cannonBall.ToString();
            cannonBallTxt.gameObject.SetActive(true);
        }
        if (weaponID != -1)
        {
            Item weapon = GameObject.FindGameObjectWithTag("Manager").GetComponentInChildren<ItemDatabase>().GetItem(weaponID);
            weaponImg.gameObject.SetActive(true);
            weaponTxt.text = weapon.itemName;
            weaponTxt.gameObject.SetActive(true);

        }

    }

    void resetAll()
    {
        goldImg.gameObject.SetActive(false);
        goldTxt.gameObject.SetActive(false);
        foodImg.gameObject.SetActive(false);
        foodTxt.gameObject.SetActive(false);
        cannonBallImg.gameObject.SetActive(false);
        cannonBallTxt.gameObject.SetActive(false);
        weaponImg.gameObject.SetActive(false);
        weaponTxt.gameObject.SetActive(false);
}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
