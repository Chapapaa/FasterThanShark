using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyIA : MonoBehaviour {

    public EnginesManager engineMng;
    ShipMap mapScr;

    Engine navEngine;
    int navEnginePriority = 1;
    Engine weaponEngine;
    int weaponEnginePriority = 2;
    Engine repairEngine;
    int repairEnginePriority = 3;
    Engine medicEngine;
    int medicEnginePriority = 4;

    Engine2 navEngine2;
    Engine2 weaponEngine2;
    Engine2 repairEngine2;
    Engine2 medicEngine2;

    List<Crew2> crew2List = new List<Crew2>();
    List<GameObject> crewList = new List<GameObject>();

    List<Engine2> eng2List = new List<Engine2>();
    List<Engine> engList = new List<Engine>();

    //int maxEnergy;

	// Use this for initialization
	void Start () {
        InitEngines();
        mapScr = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        StartCoroutine(CrewPositionManagement());


    }
	
	// Update is called once per frame
	void Update ()
    {
        if(engineMng == null)
        {
            return;
        }
        //maxEnergy = engineMng.GetEngine(Engine.engineType.power).maxPwr;
        RemovePriorityPwr();
        AddPriorityPwr();
        foreach(GameObject crew in crewList)
        {
            if(crew.GetComponent<CharacterManager>().isDead)
            {
                foreach(Crew2 crew2 in crew2List)
                {
                    if(crew2.crew == crew)
                    {
                        crew2List.Remove(crew2);
                    }
                }
                crewList.Remove(crew);
            }
        }
    }


    public void InitEngines()
    {
        navEngine = engineMng.GetEngine(Engine.engineType.navigation);
        weaponEngine = engineMng.GetEngine(Engine.engineType.weapon);
        repairEngine = engineMng.GetEngine(Engine.engineType.repair);
        medicEngine = engineMng.GetEngine(Engine.engineType.medic);
        engList.Add(navEngine);
        engList.Add(weaponEngine);
        engList.Add(repairEngine);
        engList.Add(medicEngine);
        navEngine2 = new Engine2(navEngine, navEnginePriority);
        weaponEngine2 = new Engine2(weaponEngine, weaponEnginePriority);
        repairEngine2 = new Engine2(repairEngine, repairEnginePriority);
        medicEngine2 = new Engine2(medicEngine, medicEnginePriority);
        eng2List.Add(navEngine2);
        eng2List.Add(weaponEngine2);
        eng2List.Add(repairEngine2);
        eng2List.Add(medicEngine2);


    }

    public void AddPriorityPwr()
    {
        for(int i = 0; i < 10; i++)
        {
            foreach (Engine2 eng2 in eng2List)
            {
                if (eng2.priority == i)
                {
                    engineMng.AddPowerOnEngine(eng2.engine.engine, 10);
                }
            }
        }
    }
    public void RemovePriorityPwr()
    {
        for (int i = 10; i > 0; i--)
        {
            foreach (Engine2 eng2 in eng2List)
            {
                if (eng2.priority == i)
                {
                    engineMng.RmvPowerOnEngine(eng2.engine.engine, 10);
                }
            }
        }
    }

    public void AddCrewToIA(GameObject _crew)
    {
        crewList.Add(_crew);
        crew2List.Add(new Crew2(_crew, 100));
    }

    IEnumerator CrewPositionManagement()
    {

        while(true)
        {
            yield return new WaitForSeconds(0.1f);
            if(mapScr == null)
            {
                continue;
            }
            // Si un personnage est dans une salle, update sa priority à celle actuelle de la salle
            foreach(Crew2 crew2 in crew2List)
            {
                ShipCell playerCell = crew2.crew.GetComponent<CharacterManager>().playerCell;
                if (playerCell != null )
                {
                    ShipRoom playerRoom = mapScr.GetRoomByPos(playerCell.position);
                    if(playerRoom != null)
                    {
                        Engine myEng = playerRoom.engine;
                        if (myEng != null)
                        {
                            foreach (Engine2 eng2 in eng2List)
                            {
                                if (eng2.engine == myEng)
                                {
                                    crew2.priority = eng2.priority;
                                }
                            }
                        }
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
            foreach (Crew2 crew2 in crew2List)
            {
                CharacterManager charMng = crew2.crew.GetComponent<CharacterManager>();
                float HpPercent = (charMng.currentHp * 100) / (float)charMng.maxHp;
                if (HpPercent < 40)
                {
                    if(!crew2.isHealing)
                    {
                        crew2.isHealing = true;
                        Vector3 tempPos = mapScr.GetEnginePos(Engine.engineType.medic, false);
                        crew2.crew.GetComponent<PlayerMovement>().MoveToNode(tempPos);
                    } 
                }
                else
                {
                    crew2.isHealing = false;
                }
            }
                // Si un salle est endommagée, change sa priority
                foreach (Engine2 eng2 in eng2List)
            {
                if(eng2.engine.currentHp < eng2.engine.maxHp)
                {
                    eng2.priority = 0;
                }
                else
                {
                    eng2.priority = eng2.basePriority;
                }
            }
            yield return new WaitForSeconds(0.1f);
            // envoi tous les personnages dans les salles par priorité
            foreach (Engine2 eng2 in eng2List)
            {
                Crew2 crewToMove = GetLowestPriorityMember();
                Vector3 engPosition = mapScr.GetEnginePos(eng2.engine.engine, false);
                ShipRoom room = mapScr.GetRoomByPos(engPosition);
                bool emptyRoom = true;
                foreach(ShipCell cell in room.cells)
                {
                    if (cell.enemy != null)
                    {
                        emptyRoom = false;
                    }
                }
                if(crewToMove != null)
                {
                    if (eng2.priority < crewToMove.priority && emptyRoom)
                    {
                        crewToMove.crew.GetComponent<PlayerMovement>().MoveToNode(engPosition);
                        crewToMove.priority = eng2.priority;
                    }
                }
            }          
        }
    }


    Crew2 GetLowestPriorityMember()
    {
        int maxi = -1;
        Crew2 crewResult = null;
        foreach(Crew2 crew2 in crew2List)
        {
            if(crew2.priority > maxi && !crew2.isHealing)
            {
                maxi = crew2.priority;
                crewResult = crew2;
            }
        }
        return crewResult;
    }

    class Crew2
    {

        public int priority = 100;
        public GameObject crew;
        public bool isHealing = false;
        public Crew2(GameObject _crew, int _priority)
        {
            crew = _crew;
            priority = _priority;
        }

    }

    class Engine2
    {
        public int basePriority = 100;
        public int priority = 100;
        public Engine engine;
        public Engine2(Engine _engine, int _priority )
        {
            engine = _engine;
            priority = _priority;
            basePriority = _priority;
        }
    }



}
