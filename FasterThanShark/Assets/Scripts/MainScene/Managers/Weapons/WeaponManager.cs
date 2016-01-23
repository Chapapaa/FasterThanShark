using UnityEngine;
using System.Collections;

public class WeaponManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectWeapon(int index)
    {
        // change le curseur en mode cible
        // selectionne l'arme
        print("Weapon selected : " + index);
    }
}
