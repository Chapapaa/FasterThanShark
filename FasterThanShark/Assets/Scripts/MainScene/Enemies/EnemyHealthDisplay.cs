using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour {

    public EnemyStats stats;
    public Image health1;
    public Image health2;

    float fill1 = 0f;
    float fill2 = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fill1 = stats.health1 / 10f;
        fill2 = stats.health2 / 5f;

        health1.fillAmount = fill1;
        health2.fillAmount = fill2;

    }
}
