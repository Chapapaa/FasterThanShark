using UnityEngine;
using System.Collections;

public class CannonBullet : MonoBehaviour {

    bool move = false;
    public int targetID; // 0 ally, 1 enemy, -1 autres
    public Vector3 targetPosition;
    public Vector3 startPosition;
    public float speed = 1f;
    public int bulletDamage = 1;
    public GameObject explosionGO;
    public GameObject missText;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (move && !PauseManager.isGamePaused)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f * speed);
        }
        if(transform.position == targetPosition)
        {
            HitOrMiss();
        }

    }


    public void MoveTowards(Vector3 positionStart, Vector3 positionEnd)
    {
        move = true;
        targetPosition = positionEnd;
        startPosition = positionStart;
    }

    void HitOrMiss()
    {
        if(targetID == 0)
        {
            int flee = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().flee;
            int rng = Random.Range(0, 100);
            if (rng > flee)
            {
                ShipRoom targetedRoom = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>().GetRoomByPos(targetPosition);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().GetDamage(bulletDamage, targetedRoom);
                Instantiate(explosionGO, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(missText, transform.position, Quaternion.identity);
                Vector3 newTarget = (targetPosition - startPosition) * 100f;
                targetPosition = newTarget;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f * speed);
                StartCoroutine(WaitAndDestroy());
            }
        }
        else if (targetID == 1)
        {
            EnemyManager enemyMng = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyManager>();
            if(enemyMng == null)
            {
                return;
            }
            int enemyFlee = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyStats>().flee;
            int rng = Random.Range(0, 100);
            if (rng > enemyFlee)
            {
                ShipRoom targetedRoom = GameObject.FindGameObjectWithTag("Manager").GetComponent<ShipMap>().GetRoomByPos(targetPosition);
                enemyMng.GetDamage(bulletDamage, targetedRoom);
                Instantiate(explosionGO, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Instantiate(missText, transform.position, Quaternion.identity);
                Vector3 newTarget = (targetPosition - startPosition) * 100f;
                targetPosition = newTarget;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 0.1f * speed);
                StartCoroutine(WaitAndDestroy());
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
