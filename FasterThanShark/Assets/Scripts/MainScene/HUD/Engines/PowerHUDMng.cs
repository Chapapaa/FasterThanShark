using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerHUDMng : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject maxPowerBar;
    public GameObject currentPowerBar;
    public GameObject currentPowerBarFG;
    public EnginesManager engineMng;

    bool isPointerOver;


    public void OnPointerEnter(PointerEventData eventData)
    {
        isPointerOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isPointerOver = false;
    }

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (engineMng == null) { return; }
        if (isPointerOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                engineMng.AddPowerOnEngine(Engine.engineType.power, 1);
            }
            if (Input.GetMouseButtonDown(1))
            {
                engineMng.RmvPowerOnEngine(Engine.engineType.power, 1);
            }

            if (Input.GetMouseButtonDown(3) || Input.GetKeyDown(KeyCode.O))
            {
                engineMng.GetEngine(Engine.engineType.power).LevelUp();
            }

        }


        maxPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.power).maxPwr / 10f;
        currentPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.power).currentPwr / 10f;
        currentPowerBarFG.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.power).currentPwr / 10f;


    }
}
