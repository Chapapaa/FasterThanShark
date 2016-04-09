using UnityEngine;
using System.Collections;

public class MissText : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        StartCoroutine(WaitAndDestroy());

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
