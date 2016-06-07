using UnityEngine;
using System.Collections;

public class EventsManager : MonoBehaviour {

    public int sector = 1;

    public ShipSpawnManager spawnerMng;
    public BulletSpawnerManager bulletSpawnerMng;
    public WeaponManager weaponMng;

    public GameObject modalWindow;
    ModalWindowManager modalWindowMng;
    public Transform mainCameraPos;
    public Transform shipCenterPos;
    public Transform enemyShipPos;
    public GameObject mainShip;
    public GameObject enemyShip;
    public Vector3 cameraCenter;

    bool isEnemySpawned = false;



    public void EnemyDestroyed()
    {
        bulletSpawnerMng.DestroyAllBullets();
        weaponMng.StopAttacking();
        mainCameraPos.position = new Vector3(shipCenterPos.position.x, mainCameraPos.position.y, cameraCenter.z);

        // animation de destruction du vaisseau enemy
        PauseManager.Pause();
        StandardRewardEvent();
        isEnemySpawned = false;
    }


    public void EnemyEncounter()
    {
        if(isEnemySpawned)
        {
            return;
        }
        PauseManager.Pause();
        enemyShip = spawnerMng.SpawnEnemy();
        enemyShip.transform.position = enemyShipPos.position;

        modalWindowMng.SetTitle("Ship in view !");
        modalWindowMng.SetDescription("A ship is on your way, it's a pirate ship ! \n Prepare to fight !");
        modalWindowMng.AddAwnser("Fight");
        modalWindow.SetActive(true);
        mainCameraPos.position = cameraCenter;
        isEnemySpawned = true;
    }

    // UnUSED
    public void StartBattle()
    {

        // affichage complet vaisseau
        PauseManager.Resume();
        

    }


    public void StandardEvent()
    {
        // position du vaisseau center;
        PauseManager.Pause();
        // affichage d'une fenetre modale
    }
    public void MainShipDestroyed()
    {
        // Animation de destruction du vaisseau
        PauseManager.Pause();
        modalWindowMng.SetTitle("Ship destroyed !");
        modalWindowMng.SetDescription("You ship was destroyed !\n Try again !");
        modalWindowMng.AddAwnser("Close");
        modalWindow.SetActive(true);

        // affichage du score + boutton retry
    }

    void StandardRewardEvent()
    {
        // récupere la récompense

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().gold += 10;
        modalWindowMng.SetTitle("Enemy destroyed !");
        modalWindowMng.SetDescription("you won the fight and earned 10 Golds !\n Congratulations !");
        modalWindowMng.AddAwnser("Close");
        modalWindow.SetActive(true);
        // Affichage de fenetre de récompense
        // ajout des ressources
    }

    // Use this for initialization
    void Start ()
    {
        modalWindowMng = modalWindow.GetComponent<ModalWindowManager>();
        cameraCenter = new Vector3(0f, 0f, -10f);
        mainCameraPos.position = new Vector3(shipCenterPos.position.x, mainCameraPos.position.y, cameraCenter.z);
        modalWindowMng.SetTitle("Your journey begins !");
        modalWindowMng.SetDescription("Welcome aboard captain !\n You are here to do epic stuff like saving the world or something like that ! \n So let's Go !");
        modalWindowMng.AddAwnser("Let's Start !");
        modalWindow.SetActive(true);


    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
