using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A modifier


public class HealthDisplay : MonoBehaviour {


	public int HP = 10;
	public Image healthBar;
	float health;
    PlayerStats playerStatsSCR;

	// Use this for initialization
	void Start () {
        playerStatsSCR = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        HP = playerStatsSCR.health;

        health =  HP / 10f;
		healthBar.fillAmount = health;
	
	}
}
