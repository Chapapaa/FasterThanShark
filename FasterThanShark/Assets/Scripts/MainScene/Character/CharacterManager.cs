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
    public Sprite charIcon;
    public int maxHp = 10;
    public int currentHp = 10;
    public int repairPower = 10;


    
    public int navigationOpeLevel = 1;
    public int navigationCurrentExp = 0;
    public int navigationMaxExp = 10;

    public int medicOpeLevel = 1;
    public int medicCurrentExp = 0;
    public int medicMaxExp = 10;

    public int weaponOpeLevel = 1;
    public int weaponCurrentExp = 0;
    public int weaponMaxExp = 10;

    public int repairOpeLevel = 1;
    public int repairCurrentExp = 0;
    public int repairMaxExp = 10;

    public int repairModuleOpeLevel = 1;
    public int repairModuleCurrentExp = 0;
    public int repairModuleMaxExp = 10;


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

    

    public void ChangeName(string myName)
    {
        characterName = myName;
        displayPanel2.GetComponent<CrewPanelDisplayManager>().crewName.GetComponent<InputField>().text = myName;
    }

    public int GetOperateLevel(Engine.engineType _engineType)
    {
        if(_engineType == Engine.engineType.navigation)
        {
            return navigationOpeLevel;
        }
        else if (_engineType == Engine.engineType.repair)
        {
            return repairOpeLevel;
        }
        else if (_engineType == Engine.engineType.weapon)
        {
            return weaponOpeLevel;
        }
        else if (_engineType == Engine.engineType.medic)
        {
            return medicOpeLevel;
        }
        else
        {
            return 0;
        }
        
    }

    public void GainExp(Engine.engineType engineType)
    {
        if(engineType == Engine.engineType.weapon)
        {
            weaponCurrentExp += 10;
            if(weaponCurrentExp >= weaponMaxExp)
            {
                if(weaponOpeLevel >= 6)
                {
                    weaponOpeLevel = 6;
                    weaponCurrentExp = weaponMaxExp;
                }
                else
                {
                    weaponOpeLevel += 1;
                    weaponCurrentExp -= weaponMaxExp;
                    weaponMaxExp += weaponMaxExp / weaponOpeLevel;
                }
                
            }
        }
        else if(engineType == Engine.engineType.navigation)
        {
            navigationCurrentExp += 10;
            if (navigationCurrentExp >= navigationMaxExp)
            {
                if (navigationOpeLevel >= 6)
                {
                    navigationOpeLevel = 6;
                    navigationCurrentExp = navigationMaxExp;
                }
                else
                {
                    navigationOpeLevel += 1;
                    navigationCurrentExp -= navigationMaxExp;
                    navigationMaxExp += navigationMaxExp / navigationOpeLevel;
                }
            }
        }
        else if (engineType == Engine.engineType.repair)
        {
            repairCurrentExp += 10;
            if (repairCurrentExp >= repairMaxExp)
            {
                if (repairOpeLevel >= 6)
                {
                    repairOpeLevel = 6;
                    repairCurrentExp = repairMaxExp;
                }
                else
                {
                    repairOpeLevel += 1;
                    repairCurrentExp -= repairMaxExp;
                    repairMaxExp += repairMaxExp / repairOpeLevel;
                }
            }
        }
        else if (engineType == Engine.engineType.medic)
        {
            medicCurrentExp += 10;
            if (medicCurrentExp >= medicMaxExp)
            {
                if (medicOpeLevel >= 6)
                {
                    medicOpeLevel = 6;
                    medicCurrentExp = medicMaxExp;
                }
                else
                {
                    medicOpeLevel += 1;
                    medicCurrentExp -= medicMaxExp;
                    medicMaxExp += medicMaxExp / medicOpeLevel;
                }
            }
        }
        else if (engineType == Engine.engineType.repairModule)
        {
            repairModuleCurrentExp += 10;
            if (repairModuleCurrentExp >= repairModuleMaxExp)
            {
                if (repairModuleOpeLevel >= 6)
                {
                    repairModuleOpeLevel = 6;
                    repairModuleCurrentExp = repairModuleMaxExp;
                }
                else
                {
                    repairModuleOpeLevel += 1;
                    repairModuleCurrentExp -= repairModuleMaxExp;
                    repairModuleMaxExp += repairModuleMaxExp / repairModuleOpeLevel;
                }
            }
        }
    }




    IEnumerator RepairCoroutine()
    {
        while (true)
        {
            bool repairing = false;
            if (isMoving)
            {
                yield return new WaitForSeconds(0.1f);
                continue;
            }
            if (isAlly)  // si allié et sur le ship allié
            {
                ShipRoom myRoom = globalMap.GetRoomByPos(transform.position);
                if (myRoom != null)
                {
                    if (myRoom.engine.currentHp < myRoom.engine.maxHp)
                    {
                        repairing = true;
                        myRoom.engine.Repair(repairPower + repairOpeLevel);
                        GainExp(Engine.engineType.repairModule);
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
                        myRoom.engine.Repair(repairPower + repairOpeLevel);
                    }
                }
            }
            if (repairing)
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

    IEnumerator OperateCrt()
    {
        while(true)
        {
            bool operating = false;
            if(!isRepairing && !isMoving && playerCell != null)
            {
                if(playerCell.engine != null)
                {
                    int opeLevel = GetOperateLevel(playerCell.engine.engine);
                    if (opeLevel > 0 && playerCell.engine.currentPwr > 0)
                    {
                        if (isAlly)
                        {
                            if (playerCell.position.x < 0)
                            {

                                operating = true;
                                playerCell.engine.Operate(opeLevel);
                                playerCell.engine.operatedBy = gameObject;
                                lastCell = playerCell;
                            }
                        }
                        else
                        {
                            if (playerCell.position.x > 0)
                            {
                                operating = true;
                                playerCell.engine.Operate(opeLevel);
                                playerCell.engine.operatedBy = gameObject;
                                lastCell = playerCell;
                            }
                        }
                    }
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
        while (true)
        {
            if(stopCoroutine)
            {
                stopCoroutine = false;
                break;
            }
            if(healTime >= 10f)
            {
                healTime = 0f;
                currentHp += medicEngine.currentPwr;
                if(medicEngine.operated && medicEngine.operatedBy != null)
                {
                    medicEngine.operatedBy.GetComponent<CharacterManager>().GainExp(Engine.engineType.medic);
                }
                if (currentHp >= maxHp)
                {
                    currentHp = maxHp;
                    break;
                }
            }
            yield return new WaitForSeconds(0.05f);
        }
        isHealCrtRunning = false;
    }

    IEnumerator initCrt()
    {
        yield return new WaitForSeconds(0.1f);
        Start();
    
    }


}
