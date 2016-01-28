using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public int health = 10;
    public int maxHealth = 10;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(health < 0)
        {
            health = 0;
        }
	
	}

    public void GetDamage(int amount)
    {
        health -= amount;
    }
}
