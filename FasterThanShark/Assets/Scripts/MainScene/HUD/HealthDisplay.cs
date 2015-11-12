using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// A modifier


public class HealthDisplay : MonoBehaviour {


	public int HP = 10;
	public Image healthBar;
	float health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		health = (float) HP / 10f;
		healthBar.fillAmount = health;
	
	}
}
