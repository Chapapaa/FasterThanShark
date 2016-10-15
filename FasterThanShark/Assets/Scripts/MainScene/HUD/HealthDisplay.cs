using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A modifier


public class HealthDisplay : MonoBehaviour {


	public int HP0 = 5;
    public int HP1 = 10;
    public int HP2 = 5;
    public Image healthBar0;
    public Image healthBarFG0;
    // public Image healthBar1;
    public Image healthBar2BG;
    public Image healthBar2;
    public Image healthBar2FG;
    public Text evadeText;

    float health0;
    //float health1;
    float health2;
    float health2Max;
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
        health2Max = playerStatsSCR.maxHealth2 / 4f;

        health0 = HP0 / 20f;
		healthBar0.fillAmount = health0;
        healthBarFG0.fillAmount = health0;
        //health1 = HP1 / 20f;
        //healthBar1.fillAmount = health1;
        health2 = HP2 / 4f;
        healthBar2BG.fillAmount = health2Max;
        healthBar2.fillAmount = health2;
        healthBar2FG.fillAmount = health2;
        evadeText.text = playerStatsSCR.flee.ToString();

    }
}
