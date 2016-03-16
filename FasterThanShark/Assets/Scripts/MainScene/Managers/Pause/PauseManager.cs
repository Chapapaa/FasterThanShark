using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public bool isGamePaused = false;


    public void Pause()
    {
            print("paused");
            isGamePaused = true;
            Time.timeScale = 0f;
    }

    public void Resume()
    {
        print("resumed");
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}
