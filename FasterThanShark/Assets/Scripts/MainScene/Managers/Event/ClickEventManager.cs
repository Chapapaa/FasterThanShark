using System.Collections;
using UnityEngine;

public class ClickEventManager : MonoBehaviour {

    public WeaponManager weaponSCR;
    public PathfindingManager pathMNG;
    float clickCD = 0.3f;

    

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
        if(clickCD >= 0f)
        {
            clickCD -= Time.deltaTime;
        }


    }
    public void ResetSelection()
    {
        weaponSCR.UnselectWeapon();
        pathMNG.selectedPlayer = null;

    }

    public void ClickOnRoom(int index, int buttonIndex, int map, Vector3 RoomPos)
    {
        if(clickCD >= 0 )
        {
            return;
        }
        clickCD = 0.3f;
        if (buttonIndex == 1)
        {
            pathMNG.MovePlayer(index, map);
            weaponSCR.UnselectWeapon();
        }
        if (buttonIndex == 0)
        {
            weaponSCR.UseWeapon(index, map, RoomPos);
        }
    }

    

}
