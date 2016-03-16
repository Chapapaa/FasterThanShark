using UnityEngine;
using System.Collections;

public class OptionWindowManager : MonoBehaviour {

    void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<PauseManager>().Pause();
    }
    void OnDisable()
    {
        GameObject.FindGameObjectWithTag("Manager").GetComponent<PauseManager>().Resume();
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
