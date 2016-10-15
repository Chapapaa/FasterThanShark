using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShip03Map : MonoBehaviour
{
    public int navigationLevel;
    public int weaponLevel;
    public int repairLevel;
    public int medicLevel;
    public int powerLevel;

    public GameObject navigationIcon;
    public GameObject weaponIcon;
    public GameObject repairIcon;
    public GameObject medicIcon;

    public Transform Room0;
    public Transform Room1;
    public Transform Room2;
    public Transform Room3;
    public Transform Room4;
    public Transform Room5;

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


    Engine navigationEngine;
    Engine weaponEngine;
    Engine repairEngine;
    Engine powerEngine;
    Engine medicEngine;


    ShipMap shipMap;
    List<ShipRoom> map = new List<ShipRoom>();

    public EnginesManager enginesManager;

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

    void Initialize()
    {
        InitializeEngines();
        // Taille | engine | cell 0,1(,2,3)
        map.Add(new ShipRoom(2, new Engine(), cell0.position, cell1.position,  Room0.position));
        map.Add(new ShipRoom(2, repairEngine, cell2.position, cell3.position,  Room1.position));
        map.Add(new ShipRoom(2, new Engine(), cell4.position, cell5.position, Room2.position));
        map.Add(new ShipRoom(2, weaponEngine, cell6.position, cell9.position, Room3.position));
        map.Add(new ShipRoom(4, medicEngine, cell7.position, cell8.position, cell10.position, cell11.position, Room4.position));
        map.Add(new ShipRoom(2, navigationEngine, cell12.position, cell13.position, Room5.position));

        foreach (var shipRoom in map)
        {
            if (shipRoom.engine.engine != Engine.engineType.other)
            {
                enginesManager.engines.Add(shipRoom.engine);
            }
            enginesManager.engines.Add(powerEngine);
        }
        // pour chaque room, si engine != other, on rajoute l'engine dans l'engine manager
        // Dans le manager si des degats sont subis, je regarde si la room atteinte contient un engine,
        // si c'est le cas je vais dans l'engine manager et je fais des degats a l'engine
        // pour chaque feature qui demande un engine, je vais dans l'engine manager et je check si l'engine est opérationnel


    }

    void InitializeEngines()
    {
        navigationEngine = new Engine(Engine.engineType.navigation, 0);
        navigationEngine.isActive = true;
        navigationEngine.icon = navigationIcon;

        weaponEngine = new Engine(Engine.engineType.weapon, 0);
        weaponEngine.isActive = true;
        weaponEngine.icon = weaponIcon;

        repairEngine = new Engine(Engine.engineType.repair, 0);
        repairEngine.isActive = true;
        repairEngine.icon = repairIcon;
        powerEngine = new Engine(Engine.engineType.power, 0);
        powerEngine.isActive = true;

        medicEngine = new Engine(Engine.engineType.medic, 0);
        medicEngine.isActive = true;
        medicEngine.icon = medicIcon;

        for (int i = 0; i < powerLevel; i++)
        {
            powerEngine.LevelUp();
            powerEngine.currentPwr += 1;
        }
        for (int i = 0; i < navigationLevel; i++)
        {
            navigationEngine.LevelUp();
        }
        for (int i = 0; i < weaponLevel; i++)
        {
            weaponEngine.LevelUp();
        }
        for (int i = 0; i < repairLevel; i++)
        {
            repairEngine.LevelUp();
        }
        for (int i = 0; i < medicLevel; i++)
        {
            medicEngine.LevelUp();
        }

    }

}