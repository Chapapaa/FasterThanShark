using UnityEngine;
using System.Collections;

public class OptionWindowManager : MonoBehaviour {

    void OnEnable()
    {
        PauseManager.Pause();
    }
    void OnDisable()
    {
        PauseManager.Resume();
    }

    public void ExitToWindows()
    {
        Application.Quit();
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
    }





}
