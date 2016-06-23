using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject optionPanel;
    public GameObject inventoryPanel;
    public GameObject crewPanel;
    public GameObject shopPanel;
    float inputCD = 0.5f;
    float timer = 0f;

	// Use this for initialization
	void Start () {
        

	
	}
	
	// Update is called once per frame
	void Update () {

        if (timer <= inputCD)
        {

            timer += Time.deltaTime;
        }

        if(crewPanel.activeInHierarchy)
        {
            KeyEventsManager.isInputFieldFocused = true;
        }
        else
        {
            KeyEventsManager.isInputFieldFocused = false;
        }

        if (Input.GetKeyDown(KeyCode.I) && !KeyEventsManager.isInputFieldFocused)
        {
            if(timer < inputCD)
            {
                return;
            }
            timer = 0f;
            if (inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false);
                PauseManager.Resume();
            }
            else
            {
                inventoryPanel.SetActive(true);
                PauseManager.Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape) && !KeyEventsManager.isInputFieldFocused)
        {
            if (timer < inputCD)
            {
                return;
            }
            timer = 0f;
            if (optionPanel.activeInHierarchy)
            {
                optionPanel.SetActive(false);
                PauseManager.Resume();
            }
            else
            {
                optionPanel.SetActive(true);
                PauseManager.Pause();
            }
        }
        if (Input.GetKeyDown(KeyCode.C) && !KeyEventsManager.isInputFieldFocused)
        {
            if (timer < inputCD)
            {
                return;
            }
            timer = 0f;
            if (!crewPanel.activeInHierarchy)
            {
                crewPanel.SetActive(true);
                PauseManager.Pause();
            }
            else
            {
                crewPanel.SetActive(false);
                PauseManager.Resume();
            }
        }


    }

    public void CloseInventory()
    {
        if (inventoryPanel.activeInHierarchy)
        {
            inventoryPanel.SetActive(false);
            PauseManager.Resume();
        }
    }
    public void CloseCrew()
    {
        if (crewPanel.activeInHierarchy)
        {
            crewPanel.SetActive(false);
            PauseManager.Resume();
        }
    }
    public void ClosePause()
    {
        if (optionPanel.activeInHierarchy)
        {
            optionPanel.SetActive(false);
            PauseManager.Resume();
        }
    }

    public void OpenShopPanel()
    {
        shopPanel.SetActive(true);
    }
    public void CloseShopPanel()
    {
        if (shopPanel.activeInHierarchy)
        {
            shopPanel.SetActive(false);
            PauseManager.Resume();
        }        
    }

}
