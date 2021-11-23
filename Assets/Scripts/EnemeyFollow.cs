using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemeyFollow : MonoBehaviour
{
    
    public NavMeshAgent enemy;
    public Transform Player;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //Finds the postion of the target player ands sets it to Enemy as a destination
        enemy.SetDestination(Player.position);
        
       //if the distance bettwen the enemey and the player is closer than 1 meter 
       if(enemy.remainingDistance < 1)
        {
            Debug.Log("we are close i can attack");
            this.anim.SetTrigger("Attack");
        }
    }
}
