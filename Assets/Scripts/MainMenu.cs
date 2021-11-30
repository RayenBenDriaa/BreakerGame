using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject Settings,Menu,DifficutlyEasy,DifficutlyHard;
  /*  void Awake()
    {
     #if UNITY_EDITOR
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 45;
     #endif
    }*/
    void Start()
    {
        Settings = GameObject.Find("SeetingsMenu");
        Menu = GameObject.Find("MainMenu");
        DifficutlyEasy = GameObject.Find("Text easy");
        DifficutlyHard = GameObject.Find("Text hard");
        DifficutlyHard.SetActive(false);
        Menu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("cine1");

    }
    public void GoTosettingsMenu()
    {
        
        SceneManager.LoadScene("SeetingsMenu");
        Settings.SetActive(true);
        Menu.SetActive(false);


    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Settings.SetActive(false);
        Menu.SetActive(true);


    }
    public void QuitGame()
    {
        Application.Quit();
    }
    //this function changes the difficulty to easy
    public void DiffucltyToEasy()
    {
        DifficutlyEasy.SetActive(true);
        DifficutlyHard.SetActive(false);

    }

    //this function changes the difficulty to hard
    public void DiffucltyToHard()
    {
        DifficutlyHard.SetActive(true);
        DifficutlyEasy.SetActive(false);

    }
    

}



