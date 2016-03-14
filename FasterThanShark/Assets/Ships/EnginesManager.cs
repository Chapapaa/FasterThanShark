using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnginesManager: MonoBehaviour
{


    Color redColor = new Color(1f, 0f, 0f);
    Color whiteColor = new Color(1f, 1f, 1f);

    public List<Engine> engines = new List<Engine>();


    public void GetDamageOnEngine(Engine damagedEngine, int dmgAmount)
    {
        foreach(Engine engine in engines)
        {
            if (engine == damagedEngine)
            {
                if(!engine.alive)
                { return; }
                print("damagedEngine !");
                engine.GetDamage(dmgAmount * 10);
                print(engine.currentHp);
            }
        }
    }


    void Update()
    {
        foreach(Engine engine in engines)
        {
            if(engine.icon != null)
            { 
                if(!engine.isActive)
                {
                    engine.icon.SetActive(false);
                }
                if(!engine.alive)
                {
                    engine.icon.GetComponent<SpriteRenderer>().color = redColor;
                }
                else
                {
                    engine.icon.GetComponent<SpriteRenderer>().color = whiteColor;
                }
            }
        }
    }

	public bool isWeaponEngineAlive()
    {
        foreach (Engine engine in engines)
        {
            if(engine.engine == Engine.engineType.weapon )
            {
                if(engine.alive && engine.isActive)
                {
                    return true;
                }
            }
        }
        return false;

    }

    public bool IsRepairEngineAlive()
    {
        foreach (Engine engine in engines)
        {
            if (engine.engine == Engine.engineType.repair)
            {
                if (engine.alive && engine.isActive)
                {
                    return true;
                }
            }
        }
        return false;

    }


}
