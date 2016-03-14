using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A modifier


public class HealthDisplay : MonoBehaviour {


	public int HP0 = 10;
    public int HP1 = 10;
    public int HP2 = 10;
    public Image healthBar0;
    public Image healthBar1;
    public Image healthBar2;

    float health0;
    float health1;
    float health2;
    PlayerStats playerStatsSCR;

	// Use this for initialization
	void Start () {
        playerStatsSCR = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        HP0 = playerStatsSCR.health0;
        HP1 = playerStatsSCR.health1;
        HP2 = playerStatsSCR.health2;

        health0 = HP0 / 5f;
		healthBar0.fillAmount = health0;
        health1 = HP1 / 10f;
        healthBar1.fillAmount = health1;
        health2 = HP2 / 5f;
        healthBar2.fillAmount = health2;

    }
}
