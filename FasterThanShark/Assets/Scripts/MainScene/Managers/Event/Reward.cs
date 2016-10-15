using UnityEngine;
using System.Collections;

public class Reward  {

    public int scrap = 0;
    public int food = 0;
    public int cannonball = 0;
    public Item weapon = null;

    public Reward(int _scrap, int _food, int _cannonball, Item _weapon)
    {
        scrap = _scrap;
        food = _food;
        cannonball = _cannonball;
        weapon = _weapon;
    }
}
