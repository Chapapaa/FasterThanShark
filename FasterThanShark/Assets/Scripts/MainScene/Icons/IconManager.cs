using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IconManager : MonoBehaviour {

    public EnginesManager engineManager;
    public Engine.engineType engineType;
    public GameObject baseIcon;
    public GameObject repairFront;
    public GameObject repairBack;


    Engine myEngine;
    bool isInit = false;

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadEngines());

	
	}
	
	// Update is called once per frame
	void Update () {
        if(isInit)
        {
            if(myEngine.repairAmount <= 0)
            {
                repairFront.SetActive(false);
                repairBack.SetActive(false);
            }
            else
            {
                repairFront.GetComponent<Image>().fillAmount = myEngine.repairAmount / 100f;
                repairFront.SetActive(true);
                repairBack.SetActive(true);
            }
        }



    }

    public void ChangeColor(Color color)
    {
        baseIcon.GetComponent<Image>().color = color;
    }

    IEnumerator LoadEngines()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if(engineManager.engines.Count > 0)
            {
                myEngine = engineManager.GetEngine(engineType);
                isInit = true;
                break;
            }

        }
    }
}
