using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class UpgradeIconOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public UpgradePanelManager upgradePanel;
    public GameObject PanelToDisplay;
    public bool isHover = false;
    public Engine.engineType engineType;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(isHover)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Click();
            }
                
                    
        }

	
	}
    void Click()
    {
        upgradePanel.ClickOnUpgrade(engineType);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PanelToDisplay.SetActive(true);
        isHover = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PanelToDisplay.SetActive(false);
        isHover = false;
    }
}
