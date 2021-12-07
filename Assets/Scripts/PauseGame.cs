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
        Canvasimg.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

    }
    public void resumeGame()
    {
       
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