using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnergieDisplayManagerDebug : MonoBehaviour {

    public EnginesManager engineManager;
    public Image nav0;
    public Image nav1;
    public Image nav2;
    public Image weapon0;
    public Image weapon1;
    public Image weapon2;
    public Image repair0;
    public Image repair1;
    public Image repair2;
    public Image medic0;
    public Image medic1;
    public Image medic2;





    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        nav0.fillAmount = engineManager.GetEngine(Engine.engineType.navigation).level / 10f;
        nav1.fillAmount = engineManager.GetEngine(Engine.engineType.navigation).maxPwr / 10f;
        nav2.fillAmount = engineManager.GetEngine(Engine.engineType.navigation).currentPwr / 10f;
        weapon0.fillAmount = engineManager.GetEngine(Engine.engineType.weapon).level / 10f;
        weapon1.fillAmount = engineManager.GetEngine(Engine.engineType.weapon).maxPwr / 10f;
        weapon2.fillAmount = engineManager.GetEngine(Engine.engineType.weapon).currentPwr / 10f;
        repair0.fillAmount = engineManager.GetEngine(Engine.engineType.repair).level / 10f;
        repair1.fillAmount = engineManager.GetEngine(Engine.engineType.repair).maxPwr / 10f;
        repair2.fillAmount = engineManager.GetEngine(Engine.engineType.repair).currentPwr / 10f;
        medic0.fillAmount = engineManager.GetEngine(Engine.engineType.medic).level / 10f;
        medic1.fillAmount = engineManager.GetEngine(Engine.engineType.medic).maxPwr / 10f;
        medic2.fillAmount = engineManager.GetEngine(Engine.engineType.medic).currentPwr / 10f;

        if (engineManager.GetEngine(Engine.engineType.navigation).operated)
        {
            nav2.color = Color.blue;
        }
        else
        {
            nav2.color = Color.white;
        }
        if (engineManager.GetEngine(Engine.engineType.weapon).operated)
        {
            weapon2.color = Color.blue;
        }
        else
        {
            weapon2.color = Color.white;
        }
        if (engineManager.GetEngine(Engine.engineType.repair).operated)
        {
            repair2.color = Color.blue;
        }
        else
        {
            repair2.color = Color.white;
        }
        if (engineManager.GetEngine(Engine.engineType.medic).operated)
        {
            medic2.color = Color.blue;
        }
        else
        {
            medic2.color = Color.white;
        }


    }
}
