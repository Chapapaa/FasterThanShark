using UnityEngine;
using System.Collections;

public class CrewWindowDiisplayManager : MonoBehaviour {

    public Transform containerTr;
    public GameObject charDescPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        PauseManager.Pause();
    }

}
