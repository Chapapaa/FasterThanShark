using UnityEngine;
using System.Collections;

public class CannonBullet : MonoBehaviour {

    bool move = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
        if(transform.position.y < -50f)
        {
            Destroy(gameObject);
        }

    }

    public void MoveTowards(Vector3 positionStart, Vector3 positionEnd)
    {
        move = true;
    }

}
