using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CharacterPanelDisplay : MonoBehaviour, IPointerDownHandler {

    public GameObject character;
    CharacterManager charManager;
    public GameObject healthBar;

    public GameObject nameTextPanel;

	// Use this for initialization
	void Start () {
        charManager = character.GetComponent<CharacterManager>();



    }
	
	// Update is called once per frame
	void Update ()
    {
        nameTextPanel.GetComponent<Text>().text = charManager.characterName;
        healthBar.GetComponent<Image>().fillAmount = (float)charManager.currentHp /  charManager.maxHp;


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            print(character);
            GameObject.FindGameObjectWithTag("Manager").GetComponent<PathfindingManager>().selectedPlayer = character;
        }
    }
}
