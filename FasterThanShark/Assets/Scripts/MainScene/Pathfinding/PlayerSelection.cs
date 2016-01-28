using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class PlayerSelection : MonoBehaviour
{
    BoxCollider2D selfCollider;
    float colliderx;
    float collidery;
    PathfindingManager pathfindingMNG;
    bool mouseOver = false;

	// Use this for initialization
	void Start () {
        selfCollider = transform.GetComponent<BoxCollider2D>();
        colliderx = selfCollider.size.x / 2f;
        collidery = selfCollider.size.y / 2f;
        pathfindingMNG = GameObject.FindGameObjectWithTag("Manager").GetComponent<PathfindingManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = Camera.main.transform.position.z * -1f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        float dist1 = Mathf.Abs(v3.x - transform.position.x);
        float dist2 = Mathf.Abs(v3.y - transform.position.y);
        if (dist1 < colliderx && dist2 < collidery)
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("Player selected");
                pathfindingMNG.selectedPlayer = gameObject;
            }
        }
        

    }


}
