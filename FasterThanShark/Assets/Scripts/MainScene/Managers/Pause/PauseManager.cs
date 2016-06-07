using UnityEngine;
using System.Collections;

public class PauseManager : MonoBehaviour {

    public static bool isGamePaused = false;


    public static void Pause()
    {
            print("paused");
            isGamePaused = true;
            Time.timeScale = 0f;
    }

    public static void Resume()
    {
        print("resumed");
        isGamePaused = false;
        Time.timeScale = 1f;
    }
}
