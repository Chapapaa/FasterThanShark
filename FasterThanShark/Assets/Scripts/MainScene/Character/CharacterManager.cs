using UnityEngine;
using System.Collections;

public class CharacterManager : MonoBehaviour {

    public GameObject displayPanel;

    PlayerMovement playerMvntSCR;
    public bool isAlly;
    public string characterName = "CharName";
    public int maxHp = 10;
    public int currentHp = 10;
    public int repairPower = 10;

    public bool isMoving;
    public bool isRepairing;
    public bool isOperating;

    ShipMap globalMap;

	// Use this for initialization
	void Start ()
    {
        playerMvntSCR = GetComponent<PlayerMovement>();
        globalMap = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>();
        StartCoroutine(RepairCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
    {
        isMoving = playerMvntSCR.moving;

        if (currentHp <= 0)
        {
            Death();
        }
	}

    public void Death()
    {
        Destroy(displayPanel);
        // Maj de la map
        Destroy(gameObject);
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
}
