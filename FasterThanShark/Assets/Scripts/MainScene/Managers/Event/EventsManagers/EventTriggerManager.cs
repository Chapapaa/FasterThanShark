using UnityEngine;
using System.Collections;

public class EventTriggerManager : MonoBehaviour {

    public EventWindowManager windowMng;
    public PlayerStats playerStats;
    public BulletSpawnerManager bulletSpawnerMng;

    bool isEnemySpawned = false;


    public ShipSpawnManager shipSpawnMng;


	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// event de base lors du lancement d'une nouvelle partie.
    /// </summary>
    public void StartGame()
    {
        windowMng.InstStartGameEvent();
        // affichage d'un message informant de la situation et du but de la mission.
    }

    /// <summary>
    /// event de la mort de l'enemy
    /// </summary>
    public void EnemyDeath()
    {
        isEnemySpawned = false;
        bulletSpawnerMng.DestroyAllBullets();
        windowMng.InstEnemyDeathEvent();
        // affiche un message informant de la mort du vaisseau enemy
        // affiche un message de récompense.
    }
    /// <summary>
    /// event du game over
    /// </summary>
    public void AllyDeath()
    {
        // affiche un message de fin de la partie.
    }

    /// <summary>
    ///  event de fuite.
    /// </summary>
    public void Escape()
    {
        // affichage du message de fuite et supression de l'enemy.
    }

    /// <summary>
    /// nouvel event, arrivée dans une nouvelle zone.
    /// </summary>
    public void MoveNext()
    {
        windowMng.InstStandardEvent();

        // afichage d'un message d'arrivée, en fonction de l'event, fais apparaitre un enemy.
        // pour l'instant, full random, plus tard fonction de la map.

    }

    public void GetReward(int goldAmount)
    {
        playerStats.gold += goldAmount;
    }

    public void SpawnEnemy(int index)
    {
        if (isEnemySpawned)
        {
            return;
        }
        shipSpawnMng.SpawnEnemy();
        isEnemySpawned = true;
    }




}
