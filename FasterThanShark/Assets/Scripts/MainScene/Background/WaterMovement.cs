using UnityEngine;
using System.Collections;

public class WaterMovement : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
  
	}
}
