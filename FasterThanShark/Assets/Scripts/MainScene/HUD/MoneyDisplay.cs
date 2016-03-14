using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyDisplay : MonoBehaviour {

    public PlayerStats playerStats;
    public Text moneyDisplay;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        moneyDisplay.text = playerStats.gold.ToString();
    }
}
