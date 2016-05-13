using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainShip02Map : MonoBehaviour
{

    public GameObject weaponIcon;
    public GameObject navIcon;
    public GameObject repairIcon;

    public Transform Room0;
    public Transform Room1;
    public Transform Room2;
    public Transform Room3;
    public Transform Room4;
    public Transform Room5;
    public Transform Room6;
    public Transform Room7;
    public Transform Room8;
    public Transform Room9;
    public Transform Room10;
    public Transform Room11;

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



    Engine weaponEngine;
    Engine navEngine;
    Engine repairEngine;
    Engine powerEngine;

    Vector3 lastPosition;
    ShipMap shipMap;
    List<ShipRoom> map = new List<ShipRoom>();

    public EnginesManager enginesManager;

    // Use this for initialization
    void Start()
    {
        shipMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        enginesManager = GetComponent<EnginesManager>();

        Initialize();
        lastPosition = transform.position;
        shipMap.shipMap = map;
    }

    // Update is called once per frame
    /// <summary>
    /// Chaque Room est indexé a partir de 0, en partant du coin bas gauche de la map, en comptant chaque salle de gauche a droite par "balayage" et en montant d'une CASE a chaque fois.
    /// exemple : 
    /// #########################
    /// #######     #  6  #######
    /// #######  5  #############
    /// #############     #  4  #
    /// #   #   #   #  3  #######
    /// # 0 # 1 # 2 #############
    /// #########################
    /// </summary>
    void Initialize()
    {
        InitializeEngines();
        map.Clear();
        map.Add(new ShipRoom(2, new Engine(), cell0.position, cell1.position, Room0.position));
        map.Add(new ShipRoom(2, new Engine(), cell2.position, cell3.position, Room1.position));
        map.Add(new ShipRoom(4, new Engine(), cell4.position, cell5.position, cell8.position, cell9.position, Room2.position));
        map.Add(new ShipRoom(4, weaponEngine, cell6.position, cell7.position, cell10.position, cell11.position, Room3.position));
        map.Add(new ShipRoom(2, new Engine(), cell12.position, cell16.position, Room4.position));
        map.Add(new ShipRoom(4, new Engine(), cell13.position, cell14.position, cell17.position, cell18.position, Room5.position));
        map.Add(new ShipRoom(2, new Engine(), cell15.position, cell19.position, Room6.position));
        map.Add(new ShipRoom(4, repairEngine, cell20.position, cell21.position, cell24.position, cell25.position, Room7.position));
        map.Add(new ShipRoom(4, new Engine(), cell22.position, cell23.position, cell26.position, cell27.position, Room8.position));
        map.Add(new ShipRoom(2, new Engine(), cell28.position, cell29.position, Room9.position));
        map.Add(new ShipRoom(4, new Engine(), cell30.position, cell31.position, cell32.position, cell33.position, Room10.position));
        map.Add(new ShipRoom(2, navEngine, cell34.position, cell35.position, Room11.position));


        foreach (var shipRoom in map)
        {
            if (shipRoom.engine.engine != Engine.engineType.other)
            {
                enginesManager.engines.Add(shipRoom.engine);
            }

        }
        enginesManager.engines.Add(powerEngine);
    }

    void InitializeEngines()
    {
        navEngine = new Engine(Engine.engineType.navigation, 1);
        navEngine.isActive = true;
        navEngine.icon = navIcon;
        weaponEngine = new Engine(Engine.engineType.weapon, 1);
        weaponEngine.isActive = true;
        weaponEngine.icon = weaponIcon;
        repairEngine = new Engine(Engine.engineType.repair, 1);
        repairEngine.isActive = true;
        repairEngine.icon = repairIcon;
        powerEngine = new Engine(Engine.engineType.power, 10);
        powerEngine.currentPwr = 10;


    }




    void Update()
    {
        if (lastPosition != transform.position)
        {
            Initialize();
            lastPosition = transform.position;
            AstarPath.active.Scan();
        }

    }
}
