using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip01Map : MonoBehaviour
{

    public Transform cell0;
    public Transform cell1;
    public Transform cell2;
    public Transform cell3;
    public Transform cell4;
    public Transform cell5;
    public Transform cell6;
    public Transform cell7;
    public Transform cell8;
    public Transform cell9;
    public Transform cell10;
    public Transform cell11;
    public Transform cell12;
    public Transform cell13;
    public Transform cell14;
    public Transform cell15;
    public Transform cell16;
    public Transform cell17;
    public Transform cell18;
    public Transform cell19;
    public Transform cell20;
    public Transform cell21;
    public Transform cell22;
    public Transform cell23;
    public Transform cell24;
    public Transform cell25;
    public Transform cell26;
    public Transform cell27;
    public Transform cell28;
    public Transform cell29;
    public Transform cell30;
    public Transform cell31;
    public Transform cell32;
    public Transform cell33;
    public Transform cell34;
    public Transform cell35;


    ShipMap shipMap;
    List<ShipRoom> map = new List<ShipRoom>();

    // Use this for initialization
    void Start()
    {
        shipMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        Initialize();
        shipMap.enemyShipMap = map;
    }

    // Update is called once per frame
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
    //void Initialize()
    //{
    //    map.Add(new ShipRoom(4, "null", cell0.position, cell1.position, cell8.position, cell9.position));
    //    map.Add(new ShipRoom(2, "null", cell2.position, cell3.position));
    //    map.Add(new ShipRoom(4, "null", cell4.position, cell5.position, cell12.position, cell13.position));
    //    map.Add(new ShipRoom(2, "null", cell6.position, cell18.position));
    //    map.Add(new ShipRoom(2, "null", cell7.position, cell19.position));
    //    map.Add(new ShipRoom(4, "null", cell10.position, cell11.position, cell22.position, cell23.position));
    //    map.Add(new ShipRoom(2, "null", cell14.position, cell26.position));
    //    map.Add(new ShipRoom(4, "null", cell15.position, cell16.position, cell27.position, cell28.position));
    //    map.Add(new ShipRoom(2, "null", cell17.position, cell29.position));
    //    map.Add(new ShipRoom(4, "null", cell20.position, cell21.position, cell30.position, cell31.position));
    //    map.Add(new ShipRoom(2, "null", cell32.position, cell33.position));
    //    map.Add(new ShipRoom(4, "null", cell24.position, cell25.position, cell34.position, cell35.position));
    //}
    void Initialize()
    {
        map.Add(new ShipRoom(4, "null", cell0.position, cell1.position, cell8.position, cell9.position));
        map.Add(new ShipRoom(2, "null", cell2.position, cell3.position));
        map.Add(new ShipRoom(4, "null", cell4.position, cell5.position, cell12.position, cell13.position));
        map.Add(new ShipRoom(2, "null", cell6.position, cell18.position));
        map.Add(new ShipRoom(2, "null", cell7.position, cell19.position));
        map.Add(new ShipRoom(4, "null", cell10.position, cell11.position, cell22.position, cell23.position));
        map.Add(new ShipRoom(2, "null", cell14.position, cell26.position));
        map.Add(new ShipRoom(4, "null", cell15.position, cell16.position, cell27.position, cell28.position));
        map.Add(new ShipRoom(2, "null", cell17.position, cell29.position));
        map.Add(new ShipRoom(4, "null", cell20.position, cell21.position, cell30.position, cell31.position));
        map.Add(new ShipRoom(2, "null", cell32.position, cell33.position));
        map.Add(new ShipRoom(4, "null", cell24.position, cell25.position, cell34.position, cell35.position));
    }
}