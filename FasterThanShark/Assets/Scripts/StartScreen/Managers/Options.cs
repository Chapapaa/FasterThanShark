using UnityEngine;
using System.Collections;

public class Options : MonoBehaviour {

	public GameObject optionsPanel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ShowOptionPanel()
	{
		optionsPanel.SetActive(true);
	}

	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
	}

}
