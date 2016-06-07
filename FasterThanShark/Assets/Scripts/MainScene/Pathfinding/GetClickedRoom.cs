using UnityEngine;
using System.Collections;

public class GetClickedRoom : MonoBehaviour {

    BoxCollider2D selfCollider;
    float colliderx;
    float collidery;
    ClickEventManager eventMng;
    public int mapIndex; // 0 si ship allié , 1 si ship enemy

    /// <summary>
    /// Chaque Room est indexé a partir de 0, en partant du coin bas gauche de la map, en comptant chaque salle de gauche a droite par "balayage" et en montant d'une CASE a chaque fois.
    /// exemple : 
    /// **************************
    /// *******     *  6  ********
    /// *******  5  **************
    /// *************     *  4  **
    /// *   *   *   *  3  ********
    /// * 0 * 1 * 2 **************
    /// **************************
    /// </summary>
    public int index;

	// Use this for initialization
	void Start () {
        selfCollider = transform.GetComponent<BoxCollider2D>();
        colliderx = selfCollider.size.x / 2f;
        collidery = selfCollider.size.y / 2f;
        eventMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<ClickEventManager>();
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        

    }
    void Update()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = Camera.main.transform.position.z * -1f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        float dist1 = Mathf.Abs(v3.x - transform.position.x);
        float dist2 = Mathf.Abs(v3.y - transform.position.y);
        if (dist1 < colliderx && dist2 < collidery)
        {
            if (Input.GetMouseButton(1))
            {
                if(!PauseManager.isGamePaused)
                {
                    eventMng.ClickOnRoom(index, 1, mapIndex, transform.position);
                }
                

            }
            if (Input.GetMouseButton(0))
            {
                if (!PauseManager.isGamePaused)
                {
                    eventMng.ClickOnRoom(index, 0, mapIndex, transform.position);
                }
            }
        }


    }
}
