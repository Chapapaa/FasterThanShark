using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CrewPanelDisplayManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    public GameObject crewIcon;
    public GameObject crewName;
    public GameObject character;
    public string previousName;

    public GameObject confirmPrefabWindow;
    GameObject CharDescPanel;



    // Use this for initialization
    void Start () {
        previousName = character.GetComponent<CharacterManager>().characterName;
        CharDescPanel = GameObject.FindGameObjectWithTag("CrewPanel").GetComponent<CrewWindowDiisplayManager>().charDescPanel;
    }
	
	// Update is called once per frame
	void Update ()
    {

	
	}

    public void InitCharDisplay(Sprite icon, string charName)
    {
        crewIcon.GetComponent<Image>().sprite = icon;
        crewName.GetComponentInChildren<Text>().text = charName;
    }

    public void ChangeName()
    {
        string myName = crewName.GetComponent<InputField>().textComponent.text;
        if(myName == "")
        {
            myName = previousName;
        }
        character.GetComponent<CharacterManager>().ChangeName(myName);
        previousName = myName;

    }

    public void Dismiss()
    {
        GameObject instObj = Instantiate(confirmPrefabWindow);
        instObj.GetComponent<CharSupressValidation>().displayMng = GetComponent<CrewPanelDisplayManager>();
        instObj.GetComponent<CharSupressValidation>().SetTitle("Confirm Dismiss ?");
        string contentString = "Are you sure to fire " + character.GetComponent<CharacterManager>().characterName + " ?" ;
        instObj.GetComponent<CharSupressValidation>().SetContent(contentString);
    }

    public void ConfirmDismiss()
    {
        character.GetComponent<CharacterManager>().Death();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (CharDescPanel != null)
        {
            CharDescPanel.GetComponent<CharacterDescDisplay>().character = character;
            CharDescPanel.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (CharDescPanel != null)
        {
            CharDescPanel.SetActive(false);
            CharDescPanel.GetComponent<CharacterDescDisplay>().character = null;
        }
    }
}
