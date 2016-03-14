using UnityEngine;
using System.Collections;

public class OptionWindowManager : MonoBehaviour {

	public void ExitToWindows()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        // TD : pause on/off
        gameObject.SetActive(false);
    }




}
