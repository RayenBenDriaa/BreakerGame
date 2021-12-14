using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject Canvasimg;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Canvasimg);
        Canvasimg.SetActive(false);

    }

    private void pauseGame()
    {
        Debug.Log("i cilicked on pause ");
        //shows the pause menu
        Canvasimg.SetActive(true);
        //stop the time scale 
        Time.timeScale = 0;
        isPaused = true;

    }
    public void resumeGame()
    {
       //resume the time scale
        Time.timeScale = 1;
        isPaused = false;
     

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            pauseGame();

        }
        
    }
    
}