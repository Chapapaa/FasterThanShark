using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CrewContentManager : MonoBehaviour {

    public PlayerStats playerStats;
    public List<Character> crews = new List<Character>();
    public GameObject shopCrewPrefab;
    public GameObject crewListContainer;
    public GameObject descriptionPanel;

	// Use this for initialization
	void Start () {
        AddCrewToShop("crew 1", 0, 0, 0, 0, 50);
        AddCrewToShop("crew 2", 2, 0, 3, 0, 100);
        AddCrewToShop("crew 3", 0, 1, 0, 3, 120);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}
    
    public void AddCrewToShop(string _name, int _navLevel, int _repairLevel, int _weaponLevel, int _modRepairLevel, int _price)
    {
        Character newChar = new Character(_name, true);
        newChar.navLevel = _navLevel;
        newChar.repairLevel = _repairLevel;
        newChar.weaponLevel = _weaponLevel;
        newChar.modRepairLevel = _modRepairLevel;
        newChar.charPrice = _price;
        // Icon;
        crews.Add(newChar);
        GameObject instGO = Instantiate(shopCrewPrefab);
        instGO.transform.SetParent(crewListContainer.transform);
        ShopCrewManager shopCrewMng = instGO.GetComponent<ShopCrewManager>();
        shopCrewMng.crewMember = newChar;
        shopCrewMng.crewCtntMng = gameObject.GetComponent<CrewContentManager>();
        shopCrewMng.playerStats = playerStats;
        shopCrewMng.descriptionPanel = descriptionPanel;
    }



}
