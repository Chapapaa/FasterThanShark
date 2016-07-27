using UnityEngine;
using System.Collections;

public class StartGameEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ItemInventory>().AddItemToInventory(3);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}