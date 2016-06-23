using UnityEngine;
using System.Collections;

public class MainShip02Stats : MonoBehaviour
{

    public int crewNumber = 5;
    CharSpawnManager charSpawnMng;

    // Use this for initialization
    void Start()
    {
        charSpawnMng = GameObject.FindGameObjectWithTag("Manager").GetComponent<CharSpawnManager>();
        StartCoroutine(spawnCrt());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spawnCrt()
    {
        yield return new WaitForSeconds(0.5f);
        charSpawnMng.SpawnAlly("Crew n1");
        charSpawnMng.SpawnAlly("Crew n2");
        charSpawnMng.SpawnAlly("Crew n3");
        charSpawnMng.SpawnAlly("Crew n4");
        charSpawnMng.SpawnAlly("Crew n5");
    }
}