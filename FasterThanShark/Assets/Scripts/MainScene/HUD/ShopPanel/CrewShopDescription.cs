using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CrewShopDescription : MonoBehaviour {

    public Character crew;

    public Text charName;
    public Image charIcon;
    public Text navLvl;
    public Text shieldLvl;
    public Text repairLvl;
    public Text weaponLvl;
    public Text medicLvl;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
       
        charName.text = crew.charName;
        //charIcon.sprite = mng.charIcon;
        navLvl.text = crew.navLevel.ToString();
        shieldLvl.text = crew.repairLevel.ToString();
        repairLvl.text = crew.modRepairLevel.ToString();
        weaponLvl.text = crew.weaponLevel.ToString();
        medicLvl.text = crew.medicLevel.ToString();
    }

}
