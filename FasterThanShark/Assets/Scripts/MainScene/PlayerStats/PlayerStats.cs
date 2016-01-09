using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public int health = 10;
    public int gold = 0;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health < 0)
        {
            health = 0;
        }
    }
}
