using UnityEngine;
using System.Collections;

public class Engine
{

    public engineType engine = engineType.other;
    public int maxHp = 1;
    public int currentHp = 1;
    public int level;
    public bool alive = true;

    public bool isActive = false;
    public GameObject icon;

    int repairAmount = 0;

    public enum engineType
    {
        weapon,
        navigation,
        repair,
        other
    };

    public Engine(engineType _engine, int _level)
    {
        engine = _engine;
        level = _level;
    }
    public Engine()
    {
        engine = engineType.other;
        level = 0;
    }
    public void GetDamage(int amount)
    {
        currentHp -= amount;
        if(currentHp <= 0)
        {
            currentHp = 0;
            alive = false;
        }
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
    }


}
