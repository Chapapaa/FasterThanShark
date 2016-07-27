using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopPanelManager : MonoBehaviour {

    public PlayerStats playerStats;

    public GameObject resourcesPanel;
    public GameObject weaponsPanel;
    public GameObject crewPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        PauseManager.Pause();
    }

    public void ShowRessources()
    {
        CloseAllTabs();
        resourcesPanel.SetActive(true);
    }
    public void ShowWeapons()
    {
        CloseAllTabs();
        weaponsPanel.SetActive(true);
    }
    public void ShowCrews()
    {
        CloseAllTabs();
        crewPanel.SetActive(true);
    }

    /// <summary>
    /// ferme tous les onglets
    /// </summary>
    void CloseAllTabs()
    {
        resourcesPanel.SetActive(false);
        weaponsPanel.SetActive(false);
        crewPanel.SetActive(false);
    }



}
