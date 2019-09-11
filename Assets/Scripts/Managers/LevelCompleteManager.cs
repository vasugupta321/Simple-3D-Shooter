using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class LevelCompleteManager : MonoBehaviour
{
    public static bool levelOver;
    public static bool win = false;
    public static int levelCompleteScore = 40;
    public GameObject player;
    public GameObject spawn;                    //For EnemyManager

    Animator anim;                              // Reference to the animator component
    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        levelOver = false;
    }
    // Update is called once per frame
    void Update()
    {
       
        // If the player has reached the target score
        if (ScoreManager.score == levelCompleteScore)
        {
            win = true;
            anim.SetTrigger("LevelComplete");
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Invoke("NextLevel", 2f);
            }
            levelOver = true;
            spawn.GetComponent<EnemyManager>().CancelSpawn();
            player.GetComponent<PlayerMovement>().stopMovement();
        }
    }
    void NextLevel()
    {
        win = false;
        SceneManager.LoadScene("Level 02");
    }
}
