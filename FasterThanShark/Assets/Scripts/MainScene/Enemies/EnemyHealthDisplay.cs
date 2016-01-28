using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour {

    public EnemyStats stats;
    float fill = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fill = stats.health / (float)stats.maxHealth;

        GetComponent<Image>().fillAmount = fill;
	
	}
}
