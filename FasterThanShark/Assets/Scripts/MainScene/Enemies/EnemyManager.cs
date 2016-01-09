using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    EnemyStats statsSCR;

	// Use this for initialization
	void Start ()
    {
        statsSCR = GetComponent<EnemyStats>();
    }
	
    public void GetDamage(int amount)
    {
        statsSCR.GetDamage(amount);
    }

}
