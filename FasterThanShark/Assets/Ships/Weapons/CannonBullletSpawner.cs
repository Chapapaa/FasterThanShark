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

    // OSEF
    //public void SpawnBullet()
    //{
    //    GameObject instBullet = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
    //    instBullet.transform.position = transform.position;

    //    instBullet.GetComponent<CannonBullet>().MoveTowards(transform.position, targetPosition);
    //    instBullet.GetComponent<CannonBullet>().targetID = -1;
    //    instBullet.GetComponent<ShaderRenderOrder>().renderQueueValue = shaderOrder;

    //    // OSEF 
    //    if(selectedCamera == 0)
    //    {
    //        Transform[] transforms = instBullet.GetComponentsInChildren<Transform>();
    //        foreach(var x in transforms)
    //        {
    //            x.gameObject.layer = 0;
    //        }
    //    }
    //    if (selectedCamera == 1)
    //    {
    //        Transform[] transforms = instBullet.GetComponentsInChildren<Transform>();
    //        foreach (var x in transforms)
    //        {
    //            x.gameObject.layer = 11;
    //        }
    //    }
    //}

    public void SpawnBullet(Vector3 _targetPos, int targetID)
    {
        GameObject instBullet = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
        instBullet.transform.position = transform.position;

        instBullet.GetComponent<CannonBullet>().MoveTowards(transform.position, _targetPos);
        instBullet.GetComponent<CannonBullet>().targetID = targetID;
        
    }

}
