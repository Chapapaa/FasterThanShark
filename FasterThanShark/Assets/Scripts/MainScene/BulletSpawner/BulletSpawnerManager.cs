using UnityEngine;
using System.Collections;

public class BulletSpawnerManager : MonoBehaviour {



    public void DestroyAllBullets()
    {
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
