using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharHealthDisplay : MonoBehaviour {

    public CharacterManager charMng;
    public Image healthBar;
    public Color redColor;
    public Color greenColor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int hp = charMng.currentHp;
        int maxHp = charMng.maxHp;
        if(hp < maxHp)
        {
            float hpPercent = (float)hp / maxHp;
            healthBar.fillAmount = hpPercent;
            if (hpPercent <= 0.1f)
            {
                healthBar.color = redColor;
            }
            else
            {
                healthBar.color = greenColor;
            }
        }
        else
        {
            healthBar.color = Color.clear;
        }
       
	
	}
}
