using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerResourcesDisplay : MonoBehaviour {

    public PlayerStats stats;
    public Text goldTxt;
    public Text foodTxt;
    public Text cannonballTxt;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        goldTxt.text = stats.gold.ToString();
        foodTxt.text = stats.food.ToString();
        cannonballTxt.text = stats.cannonball.ToString();



    }
}
