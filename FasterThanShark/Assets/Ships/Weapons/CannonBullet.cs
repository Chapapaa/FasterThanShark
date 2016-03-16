using UnityEngine;
using System.Collections;

public class CannonBullet : MonoBehaviour {

    bool move = false;
    public Vector3 targetPosition;
    public float speed = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f * speed);
        }
        if(transform.position == targetPosition)
        {
            Destroy(gameObject);
        }

    }

    public void MoveTowards(Vector3 positionStart, Vector3 positionEnd)
    {
        move = true;
        targetPosition = positionEnd;
    }

}
