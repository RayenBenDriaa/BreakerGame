using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameObject Settings,Menu;
    void Start()
    {
        Settings = GameObject.Find("SeetingsMenu");
        Menu = GameObject.Find("MainMenu");
        Menu.SetActive(false);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

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
}


