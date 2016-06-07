using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnginesManager: MonoBehaviour
{


    Color redColor = new Color(1f, 0f, 0f);
    Color whiteColor = new Color(1f, 1f, 1f);
    Color orangeColor = Color.yellow;

    public List<Engine> engines = new List<Engine>();


    public void GetDamageOnEngine(Engine damagedEngine, int dmgAmount)
    {
        foreach(Engine engine in engines)
        {
            if (engine == damagedEngine)
            {
                if(!engine.alive)
                { return; }
                engine.GetDamage(dmgAmount);
                if(engine.currentPwr > engine.maxPwr)
                {
                    int pwrOverflow = engine.currentPwr - engine.maxPwr;
                    engine.currentPwr -= pwrOverflow;
                    GetEngine(Engine.engineType.power).currentPwr += pwrOverflow;

                }

            }
        }
    }

    public Engine GetEngine(Engine.engineType type)
    {
        foreach(Engine engine in engines)
        {
            if(engine.engine == type)
            {
                return engine;
            }
        }
        return null;
    }


    void Update()
    {
        foreach(Engine engine in engines)
        {
            if(engine.icon != null && engine.icon.GetComponent<IconManager>() != null)
            { 
                if(!engine.isActive)
                {
                    engine.icon.SetActive(false);
                }
                if(!engine.alive)
                {
                    engine.icon.GetComponent<IconManager>().ChangeColor(redColor);
                }
                else if (engine.currentHp < engine.maxHp)
                {
                    engine.icon.GetComponent<IconManager>().ChangeColor(orangeColor); 
                }
                else
                {
                    engine.icon.GetComponent<IconManager>().ChangeColor(whiteColor);
                }
            }
        }
    }

    // !!!!!!!!!
	public bool isWeaponEngineAlive()
    {
        foreach (Engine engine in engines)
        {
            if(engine.engine == Engine.engineType.weapon )
            {
                if (engine.alive && engine.isActive && engine.currentPwr > 0)
                {
                    return true;
                }
            }
        }
        return false;
    }
    //

    public bool isNavigationEngineAlive()
    {
        foreach (Engine engine in engines)
        {
            if (engine.engine == Engine.engineType.navigation)
            {
                if (engine.alive && engine.isActive && engine.currentPwr > 0)
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
                if (engine.alive && engine.isActive && engine.currentPwr > 0)
                {
                    return true;
                }
            }
        }
        return false;

    }
    public bool IsMedicEngineAlive()
    {
        foreach (Engine engine in engines)
        {
            if (engine.engine == Engine.engineType.medic)
            {
                if (engine.alive && engine.isActive && engine.currentPwr > 0)
                {
                    return true;
                }
            }
        }
        return false;

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="engine">Navigation,Repair,Weapon</param>
    public void AddPowerOnEngine(Engine.engineType engineType, int amount)
    {
        Engine powerEngine = GetEngine(Engine.engineType.power);
        Engine myEngine = GetEngine(engineType);
        if(myEngine == null || powerEngine == null)
        {
            Debug.Log("wrong engine type");
            return;
        }
        if(amount > powerEngine.currentPwr)
        {
            amount = powerEngine.currentPwr;
        }
        if(myEngine.currentPwr + amount > myEngine.maxPwr)
        {
            amount = myEngine.maxPwr - myEngine.currentPwr;
        }
        if (amount <= powerEngine.currentPwr && myEngine.currentPwr + amount <= myEngine.maxPwr)
        {
            powerEngine.currentPwr -= amount;
            myEngine.currentPwr += amount;
        }

    }
    public void RmvPowerOnEngine(Engine.engineType engineType, int amount)
    {
        Engine powerEngine = GetEngine(Engine.engineType.power);
        Engine myEngine = GetEngine(engineType);
        if (myEngine == null || powerEngine == null)
        {
            Debug.Log("wrong engine type");
            return;
        }
        if (amount > myEngine.currentPwr)
        {
            amount = myEngine.currentPwr;
        }
        myEngine.currentPwr -= amount;
        powerEngine.currentPwr += amount;
    }

}
