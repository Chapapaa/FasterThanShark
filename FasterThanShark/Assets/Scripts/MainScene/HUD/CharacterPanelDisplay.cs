using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterPanelDisplay : MonoBehaviour {

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
}
