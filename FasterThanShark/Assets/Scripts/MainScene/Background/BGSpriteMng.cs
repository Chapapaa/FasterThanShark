using UnityEngine;
using System.Collections;

public class BGSpriteMng : MonoBehaviour {

    public GameObject spriteSpawnPos;
    public GameObject backgroundSprite;

    GameObject BG_0;
    GameObject BG_1;


	// Use this for initialization
	void Start ()
    {
        BG_0 = Instantiate(backgroundSprite);
        BG_0.transform.SetParent(gameObject.transform);
        BG_0.transform.position = new Vector3(BG_0.transform.position.x, BG_0.transform.position.y, gameObject.transform.position.z);
        BG_1 = (GameObject)Instantiate(backgroundSprite, spriteSpawnPos.transform.position, spriteSpawnPos.transform.rotation);
        BG_1.transform.SetParent(gameObject.transform);
        BG_1.transform.position = new Vector3(BG_1.transform.position.x, BG_1.transform.position.y, gameObject.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        if(BG_0.transform.position.y <= -1 * spriteSpawnPos.transform.position.y)
        {
            Destroy(BG_0);
            BG_0 = BG_1;
            BG_1 = (GameObject) Instantiate(backgroundSprite, spriteSpawnPos.transform.position, spriteSpawnPos.transform.rotation);
            BG_1.transform.SetParent(gameObject.transform);
            BG_1.transform.position = new Vector3(BG_1.transform.position.x, BG_1.transform.position.y, gameObject.transform.position.z);

        }
	
	}
}
