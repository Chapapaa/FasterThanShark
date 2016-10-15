using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterDescription : MonoBehaviour {

    public GameObject character;
    public Text charName;
    public Text charHp;
    public Image charNavExp;
    public Text charNavLvl;
    public Image charWpnExp;
    public Text charWpnLvl;
    public Image charShdExp;
    public Text charShdLvl;
    public Image charMdcExp;
    public Text charMdcLvl;
    public Image charRprExp;
    public Text charRprLvl;


    // Use this for initialization
    void Start () {
	
	}
	void OnEnable()
    {
        if(character != null)
        {
            RefreshPanel();
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
	// Update is called once per frame
	void Update () {
	
	}

    void RefreshPanel()
    {
        CharacterManager charMng = character.GetComponent<CharacterManager>();
        charName.text = charMng.characterName;
        charHp.text = charMng.currentHp.ToString() + " / " + charMng.maxHp.ToString();
        charNavExp.fillAmount = charMng.navigationCurrentExp / (float)charMng.navigationMaxExp;
        charNavLvl.text = charMng.navigationOpeLevel.ToString();
        charWpnExp.fillAmount = charMng.weaponCurrentExp / (float)charMng.weaponMaxExp;
        charWpnLvl.text = charMng.weaponOpeLevel.ToString();
        charShdExp.fillAmount = charMng.repairCurrentExp / (float)charMng.repairMaxExp;
        charShdLvl.text = charMng.repairOpeLevel.ToString();
        charMdcExp.fillAmount = charMng.medicCurrentExp / (float)charMng.medicMaxExp;
        charMdcLvl.text = charMng.medicOpeLevel.ToString();
        charRprExp.fillAmount = charMng.repairModuleCurrentExp / (float)charMng.repairModuleMaxExp;
        charRprLvl.text = charMng.repairModuleOpeLevel.ToString();
    }
}
