using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AutoFireButton : MonoBehaviour {

    public WeaponManager weaponManager;
    bool isAuto = false;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void ToggleAutoFire()
    {
        isAuto = !isAuto;
        if(isAuto)
        {
            gameObject.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            gameObject.GetComponent<Image>().color = Color.white;
        }
        weaponManager.autoFire = isAuto;

    }
}
