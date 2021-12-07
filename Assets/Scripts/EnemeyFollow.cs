using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemeyFollow : MonoBehaviour
{
    
    public NavMeshAgent enemy;
    public Transform Player;
    public Animator anim;
    public GameManger healthbar;
    float maxHealth = 100;
    float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxhealth(maxHealth);
    }
    void givedamage(float dmg)
    {
        currentHealth -= dmg;
        healthbar.Sethealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {   
        //Finds the postion of the target player ands sets it to Enemy as a destination
        enemy.SetDestination(Player.position);
        
       //if the distance bettwen the enemey and the player is closer than 1 meters 
       if(enemy.remainingDistance < 0.8)
        {
            Debug.Log("Doing Damage");
            this.anim.SetTrigger("Attack");
            givedamage(0.5f);

        }
    }

}
