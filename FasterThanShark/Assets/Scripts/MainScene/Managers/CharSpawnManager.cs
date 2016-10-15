using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSpawnManager : MonoBehaviour {

    public Sprite charBasicIcon;
    public int maxSpawnerChars = 12;
    int currentSpawnerChars = 0;

    public Vector3 spawnPosition;  // initialisé par le ship dès le spawn
    public GameObject mapCrewContainer; // range les char au bon endroit (optionnel)
    public GameObject character;    // prefab a spawn

    public GameObject allyCharDisplayPanel;     // prefab du panel du personnage (panel left)
    public GameObject allyCharDisplayPanelContainer;    // Container parent du panel du personnage
    public GameObject allyCharDescriptionPanel;

    public GameObject allyCharDisplayPanel2;     // prefab du panel du personnage ( crew window )
    public GameObject allyCharDisplayPanelContainer2;    // Container parent du panel du personnage

    public void SpawnAlly()
    {

        SpawnAlly("charName");

    }

    public void SpawnAlly(string charName)
    {
        currentSpawnerChars = mapCrewContainer.transform.childCount;
        if (currentSpawnerChars >= maxSpawnerChars) { return; }
        GameObject spawnedChar = (GameObject)Instantiate(character, spawnPosition, transform.rotation);
        spawnedChar.transform.SetParent(mapCrewContainer.transform);
        GameObject spawnerCharPanel = Instantiate(allyCharDisplayPanel);
        spawnerCharPanel.transform.SetParent(allyCharDisplayPanelContainer.transform);
        spawnerCharPanel.GetComponent<CharacterPanelDisplay>().character = spawnedChar;
        spawnerCharPanel.GetComponent<CharacterPanelDisplay>().charDescPanel = allyCharDescriptionPanel;
        GameObject spawnerCharWindowPanel = Instantiate(allyCharDisplayPanel2);
        spawnerCharWindowPanel.transform.SetParent(allyCharDisplayPanelContainer2.transform);
        spawnerCharWindowPanel.GetComponent<CrewPanelDisplayManager>().character = spawnedChar;
        spawnerCharWindowPanel.GetComponent<CrewPanelDisplayManager>().InitCharDisplay(character.GetComponentInChildren<SpriteRenderer>().sprite, charName);
        CharacterManager charMng = spawnedChar.GetComponent<CharacterManager>();
        charMng.isAlly = true;
        charMng.characterName = charName;
        charMng.displayPanel = spawnerCharPanel;
        charMng.displayPanel2 = spawnerCharWindowPanel;
        charMng.charIcon = charBasicIcon;

    }

    public void SpawnAlly(string charName, int _navLevel, int _repairLevel, int _weaponLevel, int _modRepairLevel, int _medicLevel)
    {
        currentSpawnerChars = mapCrewContainer.transform.childCount;
        if (currentSpawnerChars >= maxSpawnerChars) { return; }
        GameObject spawnedChar = (GameObject)Instantiate(character, spawnPosition, transform.rotation);
        spawnedChar.transform.SetParent(mapCrewContainer.transform);
        GameObject spawnerCharPanel = Instantiate(allyCharDisplayPanel);
        spawnerCharPanel.transform.SetParent(allyCharDisplayPanelContainer.transform);
        spawnerCharPanel.GetComponent<CharacterPanelDisplay>().character = spawnedChar;
        spawnerCharPanel.GetComponent<CharacterPanelDisplay>().charDescPanel = allyCharDescriptionPanel;
        GameObject spawnerCharWindowPanel = Instantiate(allyCharDisplayPanel2);
        spawnerCharWindowPanel.transform.SetParent(allyCharDisplayPanelContainer2.transform);
        spawnerCharWindowPanel.GetComponent<CrewPanelDisplayManager>().character = spawnedChar;
        spawnerCharWindowPanel.GetComponent<CrewPanelDisplayManager>().InitCharDisplay(character.GetComponentInChildren<SpriteRenderer>().sprite, charName);
        CharacterManager charMng = spawnedChar.GetComponent<CharacterManager>();
        charMng.charIcon = charBasicIcon;
        charMng.isAlly = true;
        charMng.characterName = charName;
        charMng.displayPanel = spawnerCharPanel;
        charMng.displayPanel2 = spawnerCharWindowPanel;
        charMng.navigationOpeLevel = _navLevel;
        charMng.repairOpeLevel = _repairLevel;
        charMng.medicOpeLevel = _medicLevel;

    }


    void Update()
    {
        
    }

}
