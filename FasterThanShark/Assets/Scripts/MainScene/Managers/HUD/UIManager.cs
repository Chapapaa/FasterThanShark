using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject optionPanel;
    public GameObject inventoryPanel;
    public PauseManager pauseMng;
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
        if (Input.GetKey(KeyCode.I))
        {
            if(timer < inputCD)
            {
                return;
            }
            timer = 0f;
            if (inventoryPanel.activeInHierarchy)
            {
                inventoryPanel.SetActive(false);
            }
            else
            {
                inventoryPanel.SetActive(true);
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            if (timer < inputCD)
            {
                return;
            }
            timer = 0f;
            if (optionPanel.activeInHierarchy)
            {
                optionPanel.SetActive(false);
                pauseMng.Pause();
            }
            else
            {
                optionPanel.SetActive(true);
                pauseMng.Pause();
            }
        }
    }
}
