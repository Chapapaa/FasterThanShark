using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WeaponHUDMng : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject maxPowerBar;
    public GameObject currentPowerBar;
    public EnginesManager engineMng;
    public GameObject levelPowerBar;

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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (engineMng == null) { return; }
        if (isPointerOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                engineMng.AddPowerOnEngine(Engine.engineType.weapon, 1);
            }
            if (Input.GetMouseButtonDown(1))
            {
                engineMng.RmvPowerOnEngine(Engine.engineType.weapon, 1);
            }

            if (Input.GetMouseButtonDown(3) || Input.GetKeyDown(KeyCode.O))
            {
                engineMng.GetEngine(Engine.engineType.weapon).LevelUp();
            }

        }
        if (engineMng.GetEngine(Engine.engineType.weapon).operated)
        {
            currentPowerBar.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            currentPowerBar.GetComponent<Image>().color = Color.white;
        }
        maxPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.weapon).maxPwr / 10f;
        currentPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.weapon).currentPwr / 10f;
        levelPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.weapon).level / 10f;


    }


}