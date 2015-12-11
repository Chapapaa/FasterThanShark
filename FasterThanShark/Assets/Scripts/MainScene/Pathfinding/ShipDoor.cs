using UnityEngine;
using System.Collections;

public class ShipDoor : MonoBehaviour {

	public Map_Ship01 worldMap;
	public string axis;
	public int posX;
	public int posY;
    bool colored = false;
    Color myColor;


    void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			OpenCloseDoor();
		}
	}

	void OpenCloseDoor()
	{
        if (!colored)
        {
            myColor = new Color(255f, 0f, 0f, 255f);
            colored = !colored;
        }
        else
        {
            myColor = new Color(255f, 255f, 255f, 255f);
            colored = !colored;
        }
        gameObject.GetComponent<SpriteRenderer>().color = myColor;
        Door myDoor = worldMap.GetDoor(axis, posX, posY);
        myDoor.open = !myDoor.open;
	}


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
