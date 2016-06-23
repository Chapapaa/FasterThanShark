using UnityEngine;
using System.Collections;

public class CannonBullletSpawner : MonoBehaviour {

    public GameObject bulletPrefab;
    Vector3 targetPosition;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    

    public void SpawnBullet(Vector3 _targetPos, int targetID, int itemDamage)
    {
        GameObject instBullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        instBullet.transform.position = transform.position;

        instBullet.GetComponent<CannonBullet>().MoveTowards(transform.position, _targetPos);
        instBullet.GetComponent<CannonBullet>().targetID = targetID;
        instBullet.GetComponent<CannonBullet>().bulletDamage = itemDamage;


    }

}
