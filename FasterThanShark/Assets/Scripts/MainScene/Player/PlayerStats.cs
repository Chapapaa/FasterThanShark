using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int health = 10;
    public int gold = 0;

    public int health0 = 5;
    public int maxHealth0 = 5;
    public int health1 = 5;
    public int maxHealth1 = 5;
    public int health2 = 5;
    public int maxHealth2 = 5;


    public int flee = 0;
    public int maxFlee = 100;

    public int currentPwr = 0;
    public int maxPwr = 0;

    public EnginesManager engineMng = null;




    // Use this for initialization
    void Start ()
    {
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(engineMng != null)
        {
            maxFlee = engineMng.GetEngine(Engine.engineType.navigation).currentPwr * 10;
            maxHealth2 = engineMng.GetEngine(Engine.engineType.repair).currentPwr;
        }
        if(health0 > maxHealth0)
        {
            health0 = maxHealth0;
        }
        if (health1 > maxHealth1)
        {
            health1 = maxHealth1;
        }
        if (health2 > maxHealth2)
        {
            health2 = maxHealth2;
        }

    }

    void Death()
    {
        health = 0;

    }


    public int GetTrueDamage(int amount)
    {
        int remainDamage2 = amount - health2;
        if (remainDamage2 < 0)
        {
            remainDamage2 = 0;
        }
        health2 -= amount;
        if (health2 < 0)
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
        if (health0 < 0)
        {
            health0 = 0;
            Death();
        }
        return remainDamage2;

    }

    

}
