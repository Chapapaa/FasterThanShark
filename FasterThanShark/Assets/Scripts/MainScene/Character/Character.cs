using UnityEngine;
using System.Collections;

public class Character {

    public string charName;
    public bool isAlly;
    public int charPrice = 0;
    public Vector3 position;
    public Sprite charIcon;


    public int navLevel = 0;
    public int navExp = 0;
    public int repairLevel = 0;
    public int repairExp = 0;
    public int weaponLevel = 0;
    public int weaponExp = 0;
    public int modRepairLevel = 0;
    public int modRepairExp = 0;
    public int medicLevel = 0;
    public int medicExp = 0;


    public Character(string _charName, bool _isAlly)
    {
        charName = _charName;
        isAlly = _isAlly;
    }
}
