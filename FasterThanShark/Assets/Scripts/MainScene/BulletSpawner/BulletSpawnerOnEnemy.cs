using UnityEngine;
using System.Collections;

public class BulletSpawnerOnEnemy : MonoBehaviour {


    public float distanceFromShip;

    // maths stuff
    float radius;
    float x;
    float y;

    void Start()
    {
        radius = distanceFromShip;

    }

    public Vector3 GetPositionToSpawn(Vector2 center)
    {
        Vector3 result = new Vector3();

        x = Random.Range((center.x - radius), (center.x + radius));
        float A = 2 * center.y;
        float B = (radius * radius) - (x * x) + (2 * x * center.x) - (center.x * center.x) - (center.y * center.y);
        int rand2 = Random.Range(0, 2);
        if (rand2 == 0)
        {
            float I = (A + Mathf.Sqrt((A * A) + (4 * B))) / 2f;
            result = new Vector3(x, I, transform.position.z);
        }
        else
        {
            float J = (A - Mathf.Sqrt((A * A) + (4 * B))) / 2f;
            result = new Vector3(x, J, transform.position.z);
        }
        return result;
    }

    

    public void SpawnBullet(int damage, GameObject bulletGO, Vector3 targetPos)
    {
        Vector3 spawnPosition = GetPositionToSpawn(targetPos);
        StartCoroutine(Spawn(bulletGO, damage, spawnPosition, targetPos));
    }

    IEnumerator Spawn(GameObject bullet, int damage, Vector3 position, Vector3 targetPosition)
    {
        yield return new WaitForSeconds(1.5f);
        GameObject instBullet = Instantiate(bullet);
        instBullet.transform.position = position;
        instBullet.GetComponent<CannonBullet>().MoveTowards(position, targetPosition);
        instBullet.GetComponent<CannonBullet>().targetID = 1;
        instBullet.GetComponent<CannonBullet>().bulletDamage = damage;
    }

    // Use this for initialization
 

    // Update is called once per frame
    void Update () {
	
	}
}
