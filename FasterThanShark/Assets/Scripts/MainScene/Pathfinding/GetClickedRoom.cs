using UnityEngine;
using System.Collections;

public class GetClickedRoom : MonoBehaviour {

    ClickEventManager eventMng;

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
        eventMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<ClickEventManager>();
    }

    // Update is called once per frame
    void OnMouseOver()
    {
        if (Input.GetMouseButton(1))
        {
            eventMng.ClickOnRoom(index, 1);

        }
        if (Input.GetMouseButton(0))
        {
            eventMng.ClickOnRoom(index, 0);

        }

    }
}
