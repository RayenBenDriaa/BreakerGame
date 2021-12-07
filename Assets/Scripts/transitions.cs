using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class transitions : MonoBehaviour
{


    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Jump"))
        {//loading scene
            if (level == 1)
            {
                SceneManager.LoadScene("Level2Scene");
            }
            else if (level == 2)
            {
                SceneManager.LoadScene("Level1Scene");
            }

        }
        
    }
}
