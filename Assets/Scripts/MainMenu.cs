using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject Settings,Menu,DifficutlyEasy,DifficutlyHard;

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
        SceneManager.LoadScene("Level2Scene");

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

    public void DiffucltyToEasy()
    {
        DifficutlyEasy.SetActive(true);
        DifficutlyHard.SetActive(false);

    }
    public void DiffucltyToHard()
    {
        DifficutlyHard.SetActive(true);
        DifficutlyEasy.SetActive(false);

    }
}



