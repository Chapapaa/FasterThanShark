using UnityEngine;
using System.Collections;

public class StartAndLoad : MonoBehaviour {
	



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame()
	{
		Application.LoadLevel("MainScene");
	}

	public void LoadGame()
	{
		print ("Chargement de la partie !");
	}


}
