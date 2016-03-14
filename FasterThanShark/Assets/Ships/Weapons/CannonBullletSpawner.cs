using UnityEngine;
using System.Collections;

public class CannonBullletSpawner : MonoBehaviour {

    public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnBullet()
    {
        GameObject instBullet = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
        instBullet.transform.position = transform.position;
        instBullet.GetComponent<CannonBullet>().MoveTowards(transform.position, transform.position);
    }

}
