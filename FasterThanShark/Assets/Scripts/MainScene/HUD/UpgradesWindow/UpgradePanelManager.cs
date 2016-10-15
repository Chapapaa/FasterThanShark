using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradePanelManager : MonoBehaviour {

    public PlayerStats stats;
    public Image powerImg;
    public Image powerImg2;
    public Image navImg;
    public Image navImg2;
    public Image weaponImg;
    public Image weaponImg2;
    public Image repairImg;
    public Image repairImg2;
    public Image medicImg;
    public Image medicImg2;
    public int powerEngineCost = 30;
    public int navEngineCost = 60;
    public int weaponEngineCost = 50;
    public int repairEngineCost = 100;
    public int medicEngineCost = 10;


    public Text actualGoldValue;
    EnginesManager engMng = null;
    Engine powerEng;
    Engine navEng;
    Engine weaponEng;
    Engine repairEng;
    Engine medicEng;
    bool isInit = false;


	// Use this for initialization
	void Start () {


    }
	
	// Update is called once per frame
	void Update () {
        actualGoldValue.text = stats.gold.ToString();
        if (engMng == null)
        {
            engMng = GameObject.FindGameObjectWithTag("MainShip").GetComponent<EnginesManager>();
            return;
        }
        else if (!isInit)
        {
            Initialize();
        }
        else
        {
            powerImg.fillAmount = powerEng.level / 10f;
            navImg.fillAmount = navEng.level / 10f;
            weaponImg.fillAmount = weaponEng.level / 10f;
            repairImg.fillAmount = repairEng.level / 10f;
            medicImg.fillAmount = medicEng.level / 10f;
            powerImg2.fillAmount = powerEng.level / 10f;
            navImg2.fillAmount = navEng.level / 10f;
            weaponImg2.fillAmount = weaponEng.level / 10f;
            repairImg2.fillAmount = repairEng.level / 10f;
            medicImg2.fillAmount = medicEng.level / 10f;
        }


}

    void Initialize()
    {
        isInit = true;
        powerEng = engMng.GetEngine(Engine.engineType.power);
        navEng = engMng.GetEngine(Engine.engineType.navigation);
        weaponEng = engMng.GetEngine(Engine.engineType.weapon);
        repairEng = engMng.GetEngine(Engine.engineType.repair);
        medicEng = engMng.GetEngine(Engine.engineType.medic);
    }

    public void ClickOnUpgrade(Engine.engineType _engineType)
    {
        if(engMng == null)
        {
            return;
        }
        Engine engineToImprove = engMng.GetEngine(_engineType);
        if(engineToImprove.level < 10)
        {
            int cost = GetEngineCost(_engineType);
            if(stats.gold >= cost)
            {
                stats.gold -= cost;
                engineToImprove.LevelUp();
            }
        }
    }

    public int GetEngineCost(Engine.engineType _engineType)
    {
        if(_engineType == Engine.engineType.power)
        {
            return powerEngineCost * engMng.GetEngine(_engineType).level;
        }
        if (_engineType == Engine.engineType.navigation)
        {
            return navEngineCost * engMng.GetEngine(_engineType).level;
        }
        if (_engineType == Engine.engineType.weapon)
        {
            return weaponEngineCost * engMng.GetEngine(_engineType).level;
        }
        if (_engineType == Engine.engineType.repair)
        {
            return repairEngineCost * engMng.GetEngine(_engineType).level;
        }
        if (_engineType == Engine.engineType.medic)
        {
            return medicEngineCost * engMng.GetEngine(_engineType).level;
        }
        return 9999;
    }


    void OnEnable()
    {
        print("Enbaled");
        PauseManager.Pause();

    }
    void OnDisable()
    {
        PauseManager.Resume();
    }
}
