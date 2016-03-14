using UnityEngine;
using System.Collections;

public class AwnserManager : MonoBehaviour {

    public GameObject ModalWindow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseModalWindow()
    {
        ModalWindow.GetComponent<ModalWindowManager>().CloseModalWindow();
    }

}
