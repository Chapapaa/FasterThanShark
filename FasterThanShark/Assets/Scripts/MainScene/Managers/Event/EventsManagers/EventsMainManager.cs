using UnityEngine;
using System.Collections;

public class EventsMainManager : MonoBehaviour {


    public EventsDatabase evntDtb;
    public ItemDatabase itemDtb;
    public EnemyShipDatabase enemyShipDtb;
    public GameObject worldMap;
    public PlayerStats playerStats;
    public ItemInventory inventory;
    public ShipSpawnManager shipSpawnMng;
    public EnemyShipSetUp shipSetUp;
    public WeaponManager weaponMng;

    public GameObject mainCamera;
    public Transform cameraMainPos;
    public Transform cameraBattlePos;
    public Transform cameraOnShip;

    public int difficulty = 0;

    public int goldReward = 0;
    public int foodReward = 0;
    public int cannonballReward = 0;
    public Item itemReward = null;

    /*  
        Escape();
        Next();
        GO ? y/n
        aff map
        DestChosen(eventType)
        GO event = EvntDtb.getEvent
        Inst event

    */

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MoveNext()
    {
        // si pas en combat
        worldMap.SetActive(true);
    }

    public void ShowEvent(int _eventId)
    {
        worldMap.SetActive(false);
        print("eventId = " + _eventId.ToString());
        GameObject eventToShow = evntDtb.GetEvent(_eventId);
        if(eventToShow != null)
        {
            GameObject instObj =  Instantiate(eventToShow);
            instObj.GetComponent<EventPanelScript>().eventMng = this;
        }
        else
        {
            Debug.Log("Event missing id : " + _eventId.ToString());
        }

    }

    public void ClaimReward()
    {
        if (goldReward > 0)
        {
            playerStats.GainGold(goldReward);
        }
        if (foodReward > 0)
        {
            playerStats.GainFood(foodReward);
        }
        if (cannonballReward > 0)
        {
            playerStats.GainCannonball(cannonballReward);
        }
        if (itemReward != null)
        {
            inventory.AddItemToInventory(itemReward.itemID);
        }

    }

    public void SetCameraPos(string _position)
    {
        if(_position == "standard")
        {
            mainCamera.transform.position = cameraMainPos.position;
        }
        if(_position == "battle")
        {
            mainCamera.transform.position = cameraBattlePos.position;
        }
        if (_position == "ship")
        {
            mainCamera.transform.position = cameraOnShip.position;
        }
    }

    public void SpawnEnemy(int shipID)
    {
        // demande à shipDatabase l'enemy à spawn
        // spawn un enemy
        // passe par le ship initializer pour l'init
    }
    public void SpawnEnemy(Ship.shipType shipType)
    {
        GameObject shipToSpawn =  enemyShipDtb.GetEnemyShip(shipType);
        GameObject spawnedShip = shipSpawnMng.SpawnEnemy(shipToSpawn);
        shipSetUp.InitShip(spawnedShip, difficulty);

    }

    public void ShowFullShip()
    {
        GameObject.FindGameObjectWithTag("MainShip").GetComponent<ShipManager>().ShowFullShip();
    }
    public void ShowHalfShip()
    {
        GameObject.FindGameObjectWithTag("MainShip").GetComponent<ShipManager>().ShowHalfShip();
    }
    public void DispawnEnemy()
    {
        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
    }

    public void EnemyDeath()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach(GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        weaponMng.StopAttacking();

        ShowEvent(20);
        SetReward();
        ClaimReward();
    }

    public void SetReward()
    {
        goldReward = Random.Range(0, 150);
        foodReward = Random.Range(0, 5);
        cannonballReward = Random.Range(0, 3);
        if (Random.Range(0, 100) < 25)
        {
            itemReward = itemDtb.GetItem(Random.Range(3, 6));
        }
        else
        {
            itemReward = null;
        }
    }
    public void SetReward(int _golds, int _food, int _cnb, int _itemID)
    {
        goldReward = _golds;
        foodReward = _food;
        cannonballReward = _cnb;
        if (_itemID > 0)
        {
            itemReward = itemDtb.GetItem(_itemID);
        }
        else
        {
            itemReward = null;
        }
    }
}
