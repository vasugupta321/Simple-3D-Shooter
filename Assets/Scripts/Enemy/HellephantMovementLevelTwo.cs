using UnityEngine;
using System.Collections;

public class HellephantMovementLevelTwo : MonoBehaviour
{
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth hellephant; 
    UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        playerHealth = player.GetComponent <PlayerHealth> ();
        hellephant = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
    }


    void Update ()
    {
        if(hellephant.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position); //heading towards the player
        }
        else
        {
            nav.enabled = false; //Disable enemy movement when player is dead
        }
    }
}
