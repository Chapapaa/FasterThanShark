using UnityEngine;
using System.Collections;

public class ShipDoor : MonoBehaviour {

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
            gameObject.layer = 9;

        }
        else
        {
            myColor = new Color(255f, 255f, 255f, 255f);
            colored = !colored;
            gameObject.layer = 0;
            
        }
        GetComponent<SpriteRenderer>().color = myColor;
        AstarPath.active.Scan();
    }


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
