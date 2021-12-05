using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;



public class Interactable : MonoBehaviour
{
    //checking if in range
    public bool isInRange;
    //our interactionKey
    public KeyCode interactKey;
    //our event invoker
    public UnityEvent interactAction;

    private void Start()
    {
        
    }
    void Update()
	{
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                // loading events
                Debug.Log("i'm clicking on e");
                interactAction.Invoke();
               
            }
        }
		
	}
    //trigger this if  our player enters the interactable
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player now in range");
        }
    }
    //trigger this if our player Exist the interactable
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player not in range");
        }

    }






}