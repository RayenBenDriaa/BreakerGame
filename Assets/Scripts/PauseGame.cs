using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject Canvasimg;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Canvasimg);
        Canvasimg.SetActive(false);

    }

    private void pausegame()
    {
        Debug.Log("i cilicked on pause ");
        Canvasimg.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("hello");
            Canvasimg.SetActive(true);

        }
    }
}