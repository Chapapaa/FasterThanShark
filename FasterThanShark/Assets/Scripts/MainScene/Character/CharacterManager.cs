using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour {

    public GameObject displayPanel;
    public GameObject displayPanel2;


    PlayerMovement playerMvntSCR;
    public EnginesManager engineMng;
    
    public ShipCell playerCell = null;
    public ShipCell lastCell = null;
    public bool isAlly;
    public string characterName = "CharName";
    public int maxHp = 10;
    public int currentHp = 10;
    public int repairPower = 10;
    public int operateLevel = 1;

    public float healTime = 0f;
    bool isHealCrtRunning = false;
    bool stopCoroutine = false;

    public bool isDead = false;
    public bool isMoving;
    public bool isRepairing;
    public bool isOperating;

    ShipMap globalMap;

    Engine medicEngine;
    List<Vector3> medicsPos = new List<Vector3>();


    // Use this for initialization
    void Start ()
    {
        playerMvntSCR = GetComponent<PlayerMovement>();
        globalMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        if (isAlly)
        {
            engineMng = GameObject.FindGameObjectWithTag("MainShip").GetComponent<EnginesManager>();
        }
        else
        {
            engineMng = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnginesManager>();
        }
        medicEngine = engineMng.GetEngine(Engine.engineType.medic);
        if (medicEngine == null)
        {
            StartCoroutine(initCrt());
            return;

        }
        Vector3 medicPos = globalMap.GetEnginePos(Engine.engineType.medic, isAlly);
        foreach (ShipCell cell in globalMap.GetRoomByPos(medicPos).cells)
        {
            medicsPos.Add(cell.position);
        }
        StartCoroutine(RepairCoroutine());
        StartCoroutine(OperateCrt());
        

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(healTime < 11f)
        {
            healTime += Time.deltaTime;
        }
        isMoving = playerMvntSCR.moving;

        if (currentHp <= 0)
        {
            Death();
        }
        if(engineMng.IsMedicEngineAlive())
        {
            if(currentHp < maxHp) 
            {
                if(isInMedicRange())
                {
                    if(!isHealCrtRunning)
                    {
                        StartCoroutine(HealCrt());
                        print("Heal !");
                    }
                    
                }
                else
                {
                    if (isHealCrtRunning)
                    {
                        stopCoroutine = true;
                    }
                }
            }
            else
            {
                if (isHealCrtRunning)
                {
                    stopCoroutine = true;
                }
            }
        }
        else
        {
            if (isHealCrtRunning)
            {
                stopCoroutine = true;
            }
        }
        
    }

    public bool isInMedicRange()
    {
        foreach(Vector3 cellPos in medicsPos)
        {
            float distX = Mathf.Abs(transform.position.x - cellPos.x);
            float distY = Mathf.Abs(transform.position.x - cellPos.x);
            if(distX < 0.5f && distY < 0.5f)
            {
                return true;
            }
        }
        return false;
    }

    public void Death()
    {
        isDead = true;
        StopCoroutine(RepairCoroutine());
        if (isOperating)
        {
            if (lastCell != null)
            {
                if (lastCell.engine != null)
                {
                    lastCell.engine.Operate(0);
                }
            }
        }
        Destroy(displayPanel);
        Destroy(displayPanel2);
        GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>().DestroyChar(gameObject);
        // Maj de la map
        StartCoroutine(DeathCrt());
    }
    public void GetDamage(int amount)
    {
        currentHp -= amount;
    }

    IEnumerator RepairCoroutine()
    {
        while(true)
        {
            bool repairing = false;
            if (isMoving)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }
            if(isAlly)  // si allié et sur le ship allié
            {
                ShipRoom myRoom = globalMap.GetRoomByPos(transform.position);
                if(myRoom != null)
                {
                    if(myRoom.engine.currentHp < myRoom.engine.maxHp)
                    {
                        repairing = true;
                        myRoom.engine.Repair(repairPower);
                    }
                }
            }
            else // si pas allié et pas sur le ship allié
            {
                ShipRoom myRoom = globalMap.GetRoomByPos(transform.position);
                if (myRoom != null)
                {
                    if (myRoom.engine.currentHp < myRoom.engine.maxHp)
                    {
                        repairing = true;
                        myRoom.engine.Repair(repairPower);
                    }
                }
            }
            if(repairing)
            {
                isRepairing = true;
            }
            else
            {
                isRepairing = false;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void ChangeName(string myName)
    {
        characterName = myName;
        displayPanel2.GetComponent<CrewPanelDisplayManager>().crewName.GetComponent<InputField>().text = myName;
    }

    IEnumerator OperateCrt()
    {
        while(true)
        {
            bool operating = false;
            if(!isRepairing && !isMoving && playerCell != null)
            {
                if(playerCell.engine != null)
                {
                    if(isAlly)
                    {
                        if(playerCell.position.x < 0)
                        {
                            operating = true;
                            playerCell.engine.Operate(operateLevel);
                            playerCell.engine.operatedBy = gameObject;
                            lastCell = playerCell;
                        }
                    }
                    else
                    {
                        if (playerCell.position.x > 0)
                        {
                            operating = true;
                            playerCell.engine.Operate(operateLevel);
                            playerCell.engine.operatedBy = gameObject;
                            lastCell = playerCell;
                        }
                    }
                    
                    // stuff d'operate.
                }
            }
            if (operating)
            {
                isOperating = true;
            }
            else
            {
                if(lastCell != null)
                {
                    if(lastCell.engine != null)
                    {
                        if(lastCell.engine.operatedBy == gameObject)
                        {
                            lastCell.engine.Operate(0);
                            lastCell.engine.operatedBy = null;
                        }
                        
                    }
                }
                isOperating = false;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator DeathCrt()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        }
    }
    
    IEnumerator HealCrt()
    {
        healTime = 0f;
        isHealCrtRunning = true;
        print("Coroutine");
        while (true)
        {
            if(stopCoroutine)
            {
                stopCoroutine = false;
                break;
            }
            if(healTime >= 10f)
            {
                print("healing done");
                healTime = 0f;
                currentHp += medicEngine.currentPwr;
                if (currentHp >= maxHp)
                {
                    currentHp = maxHp;
                    break;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
        isHealCrtRunning = false;
        print("end of crt");


    }

    IEnumerator initCrt()
    {
        yield return new WaitForSeconds(0.1f);
        Start();
    
    }


}
