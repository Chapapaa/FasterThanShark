using UnityEngine;
using System.Collections;

public class BulletSpawnerManager : MonoBehaviour {

    public BulletSpawnerOnEnemy enemyBulletSpawner;
    public BulletSpawnerOnAlly allyBulletSpawner;

    public void SpawnBulletOnEnemy(int bulletDmg, GameObject prefab, Vector3 targetPos)
    {
        enemyBulletSpawner.SpawnBullet(bulletDmg, prefab, targetPos);
    }
    public void SpawnBulletOnAlly(int bulletDmg, GameObject prefab, Vector3 targetPos)
    {
        allyBulletSpawner.SpawnBullet(bulletDmg, prefab, targetPos);
    }

    public void DestroyAllBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
        enemyBulletSpawner.StopAllCoroutines();
        allyBulletSpawner.StopAllCoroutines();
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
