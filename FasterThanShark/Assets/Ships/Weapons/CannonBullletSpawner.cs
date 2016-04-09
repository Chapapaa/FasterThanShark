using UnityEngine;
using System.Collections;

public class CannonBullletSpawner : MonoBehaviour {

    public GameObject bulletPrefab;
    public int direction; // 8,6,2,4;
    public int shaderOrder = 2000;
    public int selectedCamera = 0;
    Vector3 targetPosition;

	// Use this for initialization
	void Start () {
        if(direction == 8)
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z);
        }
        if (direction == 6)
        {
            targetPosition = new Vector3(transform.position.x + 12f, transform.position.y, transform.position.z);
        }
        if (direction == 2)
        {
            targetPosition = new Vector3(transform.position.x, transform.position.y - 100f, transform.position.z);
        }
        if (direction == 4)
        {
            targetPosition = new Vector3(transform.position.x - 12f, transform.position.y, transform.position.z);
        }



    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnBullet()
    {
        GameObject instBullet = (GameObject) Instantiate(bulletPrefab, transform.position, transform.rotation);
        instBullet.transform.position = transform.position;

        instBullet.GetComponent<CannonBullet>().MoveTowards(transform.position, targetPosition);
        instBullet.GetComponent<CannonBullet>().targetID = -1;
        instBullet.GetComponent<ShaderRenderOrder>().renderQueueValue = shaderOrder;
        if(selectedCamera == 0)
        {
            Transform[] transforms = instBullet.GetComponentsInChildren<Transform>();
            foreach(var x in transforms)
            {
                x.gameObject.layer = 0;
            }
        }
        if (selectedCamera == 1)
        {
            Transform[] transforms = instBullet.GetComponentsInChildren<Transform>();
            foreach (var x in transforms)
            {
                x.gameObject.layer = 11;
            }
        }
    }

}
