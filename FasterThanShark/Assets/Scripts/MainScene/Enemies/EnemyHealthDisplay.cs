using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthDisplay : MonoBehaviour {

    public EnemyStats stats;
    public Image health1;
    public Image heath1FG;
    public Image health2BG;
    public Image health2;
    public Image heaath2FG;

    float fill1 = 0f;
    float fill2 = 0f;
    float fill3 = 0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        fill1 = stats.health1 / 20f;
        fill2 = stats.health2 / 4f;
        fill3 = stats.maxHealth2 / 4f;

        health1.fillAmount = fill1;
        heath1FG.fillAmount = fill1;
        health2BG.fillAmount = fill3;
        health2.fillAmount = fill2;
        heaath2FG.fillAmount = fill2;


    }
}
