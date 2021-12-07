using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManger : MonoBehaviour
{
    //
    float currentTime = 0f;
    int minuteTime;
    public float startingTime;

    [SerializeField] TextMeshProUGUI countdownText;
    public Slider slider;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
        SetMaxhealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        //decremating our current time each second
        currentTime -= 1 * Time.deltaTime;
        Debug.Log(currentTime);
        //getting time in minute 
        minuteTime = (int)currentTime / 60;
        Debug.Log(minuteTime);
        //displaying our time in minute in our text
        countdownText.text = minuteTime.ToString();
    }
    //this function  is resting the max health on demande
    public void SetMaxhealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //this method for other controller to be implemented on
    public void Sethealth(float health)
    {
        slider.value = health;
    }
    


}
