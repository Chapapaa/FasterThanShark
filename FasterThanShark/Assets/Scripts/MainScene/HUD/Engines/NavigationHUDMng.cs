﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class NavigationHUDMng : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject maxPowerBar;
    public GameObject levelPowerBar;
    public GameObject levelPowerBarFG;
    public GameObject currentPowerBar;
    public GameObject currentPowerBarFG;
    public EnginesManager engineMng;

    Color greyColor = new Color(0.8f, 0.8f, 0.8f);

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
    void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if(engineMng == null) { return; }
        if(isPointerOver)
        {
            if(Input.GetMouseButtonDown(0))
            {
                engineMng.AddPowerOnEngine(Engine.engineType.navigation, 1);
            }
            if (Input.GetMouseButtonDown(1))
            {
                engineMng.RmvPowerOnEngine(Engine.engineType.navigation, 1);
            }

            if(Input.GetMouseButtonDown(3) || Input.GetKeyDown(KeyCode.O))
            {
                engineMng.GetEngine(Engine.engineType.navigation).LevelUp();
            }

        }
        if(engineMng.GetEngine(Engine.engineType.navigation).operated)
        {
            currentPowerBar.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            currentPowerBar.GetComponent<Image>().color = greyColor;
        }
        maxPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.navigation).maxPwr / 10f;
        levelPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.navigation).level / 10f;
        levelPowerBarFG.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.navigation).level / 10f;
        currentPowerBar.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.navigation).currentPwr / 10f;
        currentPowerBarFG.GetComponent<Image>().fillAmount = engineMng.GetEngine(Engine.engineType.navigation).currentPwr / 10f;
        


    }


}
