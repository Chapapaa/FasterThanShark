using UnityEngine;
using System.Collections;

public class ShipDoor : MonoBehaviour {

	public Map_Ship01 worldMap;
	public string axis;
	public int posX;
	public int posY;

	void OnMouseOver()
	{
		if(Input.GetMouseButtonDown(0))
		{
			OpenDoor();
		}
	}

	void OpenDoor()
	{
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,0f,0f,255f);
		worldMap.dX_b1.open = false;
		worldMap.dY_b3.open = false;
	}


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
