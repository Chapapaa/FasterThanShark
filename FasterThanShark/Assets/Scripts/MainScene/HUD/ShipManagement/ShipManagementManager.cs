using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipManagementManager : MonoBehaviour {

    public PlayerStats playerStats;
    public int shipEnginePrice = 50;

    public GameObject enginesPanel;
    public GameObject crewsPanel;
    public GameObject weaponsPanel;
    public GameObject upgradesPanel;

    public GameObject descContainer;
    public GameObject panelContainer;
    public GameObject enginesDescPanel;
    public GameObject crewsDescPanel;
    public GameObject weaponsDescPanel;
    public GameObject upgradesDescPanel;





    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ShowPanelOnTop()
    {
        int siblingNumber = transform.childCount;
        panelContainer.transform.SetSiblingIndex(siblingNumber - 2);
    }

    public void CloseAllTabs()
    {
        for(int i = 0; i < descContainer.transform.childCount; i++)
        {
            GameObject panel = descContainer.transform.GetChild(i).gameObject;
            panel.SetActive(false);
        }
        enginesPanel.SetActive(false);
        crewsPanel.SetActive(false);
        weaponsPanel.SetActive(false);
        upgradesPanel.SetActive(false);
        
    }
    public void ShowEngines()
    {
        CloseAllTabs();
        enginesPanel.SetActive(true);
        enginesDescPanel.SetActive(true);
    }
    public void ShowWeapons()
    {
        CloseAllTabs();
        weaponsPanel.SetActive(true);
        weaponsDescPanel.SetActive(true);
    }
    public void ShowCrews()
    {
        CloseAllTabs();
        crewsPanel.SetActive(true);
        crewsDescPanel.SetActive(true);
    }
    public void ShowUpgrades()
    {
        CloseAllTabs();
        upgradesPanel.SetActive(true);
        upgradesDescPanel.SetActive(true);
    }

    public int GetEnginePrice(Engine.engineType myType)
    {
        int level = playerStats.engineMng.GetEngine(myType).level;
        int price = level * shipEnginePrice;
        return price;
    }

    void OnEnable()
    {
        PauseManager.Pause();
        ShowEngines();
    }
    void OnDisable()
    {
        PauseManager.Resume();
    }
    
}
