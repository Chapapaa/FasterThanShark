using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharSpawnManager : MonoBehaviour {

    public Vector3 spawnPosition;  // initialisé par le ship dès le spawn
    public GameObject mapCrewContainer; // range les char au bon endroit (optionnel)

    public GameObject character;    // prefab a spawn

    public GameObject allyCharDisplayPanel;     // prefab du panel du personnage
    public GameObject allyCharDisplayPanelContainer;    // Container parent du panel du personnage

    public void SpawnAlly()
    {

        GameObject spawnedChar = (GameObject) Instantiate(character, spawnPosition, transform.rotation);
        spawnedChar.transform.SetParent(mapCrewContainer.transform);
        GameObject spawnerCharPanel = Instantiate(allyCharDisplayPanel);
        spawnerCharPanel.transform.SetParent(allyCharDisplayPanelContainer.transform);
        spawnedChar.GetComponent<CharacterManager>().isAlly = true;
        spawnedChar.GetComponent<CharacterManager>().displayPanel = spawnerCharPanel;
        spawnerCharPanel.GetComponent<CharacterPanelDisplay>().character = spawnedChar;

    }

    public void SpawnAlly(string charName)
    {

        GameObject spawnedChar = (GameObject)Instantiate(character, spawnPosition, transform.rotation);
        spawnedChar.transform.SetParent(mapCrewContainer.transform);
        GameObject spawnerCharPanel = Instantiate(allyCharDisplayPanel);
        spawnerCharPanel.transform.SetParent(allyCharDisplayPanelContainer.transform);
        spawnedChar.GetComponent<CharacterManager>().isAlly = true;
        spawnedChar.GetComponent<CharacterManager>().characterName = charName;
        spawnedChar.GetComponent<CharacterManager>().displayPanel = spawnerCharPanel;
        spawnerCharPanel.GetComponent<CharacterPanelDisplay>().character = spawnedChar;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            SpawnAlly();
        }
    }

}
