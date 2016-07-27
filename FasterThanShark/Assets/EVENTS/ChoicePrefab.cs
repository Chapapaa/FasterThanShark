using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChoicePrefab : MonoBehaviour {

    public delegate void CallBackType(int _index);
    public CallBackType CallBackFunction;
    public int index;
    public EventPanelScript eventPanelScr;
    public Text buttonText;
    public string myText;

	// Use this for initialization
	void Start ()
    {
        buttonText.text = myText;


    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void MakeChoice()
    {
        if(CallBackFunction != null)
        {

            CallBackFunction(index);
        }
    }
}
