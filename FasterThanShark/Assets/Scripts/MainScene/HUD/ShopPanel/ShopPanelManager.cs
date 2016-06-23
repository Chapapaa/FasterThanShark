﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShopPanelManager : MonoBehaviour {

    public PlayerStats playerStats;

    public GameObject ressourcesPanel;
    public GameObject weaponsPanel;

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
        ressourcesPanel.SetActive(true);
    }
    public void ShowWeapons()
    {
        CloseAllTabs();
        weaponsPanel.SetActive(true);
    }

    /// <summary>
    /// ferme tous les onglets
    /// </summary>
    void CloseAllTabs()
    {
        
        ressourcesPanel.SetActive(false);
        weaponsPanel.SetActive(false);
    }



}
