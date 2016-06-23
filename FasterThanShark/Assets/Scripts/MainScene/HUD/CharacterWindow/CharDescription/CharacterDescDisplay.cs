using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterDescDisplay : MonoBehaviour {

    public GameObject character;

    public Text charName;
    public Image charIcon;
    public Text navLvl;
    public Image navExp;
    public Text shieldLvl;
    public Image shieldExp;
    public Text repairLvl;
    public Image repairExp;
    public Text weaponLvl;
    public Image weaponExp;
    public Text medicLvl;
    public Image medicExp;




    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        if(character == null)
        {
            gameObject.SetActive(false);
            return;
        }
        CharacterManager mng = character.GetComponent<CharacterManager>();
        charName.text = mng.characterName;
        //charIcon.sprite = mng.charIcon;
        navLvl.text = mng.navigationOpeLevel.ToString() ;
        navExp.fillAmount = mng.navigationCurrentExp / (float)mng.navigationMaxExp;
        shieldLvl.text = mng.repairOpeLevel.ToString();
        shieldExp.fillAmount = mng.repairCurrentExp / (float)mng.repairMaxExp;
        repairLvl.text = mng.repairModuleOpeLevel.ToString();
        repairExp.fillAmount = mng.repairModuleCurrentExp / (float)mng.repairModuleMaxExp;
        weaponLvl.text = mng.weaponOpeLevel.ToString();
        weaponExp.fillAmount = mng.weaponCurrentExp / (float)mng.weaponMaxExp;
        medicLvl.text = mng.medicOpeLevel.ToString();
        medicExp.fillAmount = mng.medicCurrentExp / (float)mng.medicMaxExp;
    }
}
