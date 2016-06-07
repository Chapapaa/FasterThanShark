using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrewPanelDisplayManager : MonoBehaviour {

    public GameObject crewIcon;
    public GameObject crewName;
    public GameObject character;



	// Use this for initialization
	void Start () {
	
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
        character.GetComponent<CharacterManager>().ChangeName(myName);
    }



    public void Dismiss()
    {
        character.GetComponent<CharacterManager>().Death();
        // supression du personnage AVEC MESSAGE DE CONFIRMATION
    }

}
