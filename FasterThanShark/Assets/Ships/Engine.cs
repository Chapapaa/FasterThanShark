using UnityEngine;
using System.Collections;

public class Engine
{

    public engineType engine = engineType.other;
    public int currentPwr = 0;
    public int maxPwr = 0;
    public int currentHp = 1;
    public int maxHp = 1;
    public int level = 1;
    public int operateLevel = 0;
    public bool alive = true;
    public bool operated = false;

    public bool isActive = false;
    public GameObject icon;

    public GameObject operatedBy = null;

    public int repairAmount = 0;

    public enum engineType
    {
        weapon,
        navigation,
        repair,
        power,
        medic,
        repairModule, // utilisé juste pour le gian d'exp
        other
    };


    public void LevelUp()
    {
        
        maxHp += 1;
        currentHp += 1;
        maxPwr = currentHp;
        level += 1;
        if (engine == engineType.power)
        {
            currentPwr += 1;
        }
    }

    public void Operate(int opLevel)
    {
        if(opLevel == 0)
        {
            operated = false;
        }
        else
        {
            operated = true;
        }
        operateLevel = opLevel;
    }


    public Engine(engineType _engine, int _level)
    {
        engine = _engine;
        level = _level;
        maxHp = level;
        currentHp = maxHp;
        maxPwr = level;
    }
    public Engine()
    {
        engine = engineType.other;
        level = -1;
    }
    public void GetDamage(int amount)
    {
        currentHp -= amount;
        repairAmount = 0;
        if (currentHp <= 0)
        {
            currentHp = 0;
            alive = false;
        }
        maxPwr = currentHp;
    }
    public void Repair(int amount)
    {
        repairAmount += amount;
        if(repairAmount >= 100)
        {
            currentHp += 1;
            repairAmount = 0;
        }
        if(currentHp >= 1)
        {
            alive = true;
        }
        maxPwr = currentHp;
    }


}
