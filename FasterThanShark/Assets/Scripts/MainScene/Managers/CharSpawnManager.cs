using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSpawnManager : MonoBehaviour {

    public int maxSpawnerChars = 12;
    int currentSpawnerChars = 0;

    public Vector3 spawnPosition;  // initialisé par le ship dès le spawn
    public GameObject mapCrewContainer; // range les char au bon endroit (optionnel)
    public GameObject character;    // prefab a spawn

    public GameObject allyCharDisplayPanel;     // prefab du panel du personnage
    public GameObject allyCharDisplayPanelContainer;    // Container parent du panel du personnage

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
        GameObject spawnerCharWindowPanel = Instantiate(allyCharDisplayPanel2);
        spawnerCharWindowPanel.transform.SetParent(allyCharDisplayPanelContainer2.transform);
        spawnerCharWindowPanel.GetComponent<CrewPanelDisplayManager>().character = spawnedChar;
        spawnerCharWindowPanel.GetComponent<CrewPanelDisplayManager>().InitCharDisplay(character.GetComponentInChildren<SpriteRenderer>().sprite, charName);
        spawnedChar.GetComponent<CharacterManager>().isAlly = true;
        spawnedChar.GetComponent<CharacterManager>().characterName = charName;
        spawnedChar.GetComponent<CharacterManager>().displayPanel = spawnerCharPanel;
        spawnedChar.GetComponent<CharacterManager>().displayPanel2 = spawnerCharWindowPanel;


        // spawn d'un prefab dans la characterWindow

    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !KeyEventsManager.isInputFieldFocused)
        {
            Debug.Log("spawnAlly");
            SpawnAlly();
        }
    }

}
