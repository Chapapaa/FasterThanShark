using UnityEngine;
using System.Collections;

public class MainShip02Stats : MonoBehaviour
{

    public int crewNumber = 3;
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
        for (int i = 0; i < crewNumber; i++)
        {
            string name = "Crew n" + (i+1).ToString();
            charSpawnMng.SpawnAlly(name);
        }
    }
}