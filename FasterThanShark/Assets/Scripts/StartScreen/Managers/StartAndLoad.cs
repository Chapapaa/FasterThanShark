using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartAndLoad : MonoBehaviour {
	



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewGame()
	{
		SceneManager.LoadScene("MainScene");
	}

	public void LoadGame()
	{
		print ("Chargement de la partie !");
	}


}
