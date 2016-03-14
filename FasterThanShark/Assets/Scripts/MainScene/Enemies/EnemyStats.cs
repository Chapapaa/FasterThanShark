using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

    public EnemyManager enemyMngSCR;

    public int health0 = 0;
    public int maxHealth0 = 0;
    public int health1 = 10;
    public int maxHealth1 = 10;
    public int health2 = 5;
    public int maxHealth2 = 5;



    public bool alive = true;


	// Use this for initialization
	void Start () {
	
	}
	

    void Death()
    {
        health0 = 0;
        health1 = 0;
        health2 = 0;
        enemyMngSCR.Death();
        alive = false;
    }

    public int GetDamage(int amount)
    {
        int remainDamage2 = amount - health2;
        if(remainDamage2 < 0)
        {
            remainDamage2 = 0;
        }
        health2 -= amount;
        if(health2 < 0)
        {
            health2 = 0;
        }
        int remainDamage1 = remainDamage2 - health1;
        if (remainDamage1 < 0)
        {
            remainDamage1 = 0;
        }
        health1 -= remainDamage2;
        if (health1 < 0)
        {
            health1 = 0;
        }
        health0 -= remainDamage1;
        if (health0 <= 0 && health1 <= 0)
        {
            health0 = 0;
            Death();
        }
        
        return remainDamage2;

    }
}
