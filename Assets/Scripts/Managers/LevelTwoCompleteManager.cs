using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTwoCompleteManager : MonoBehaviour
{
    public GameObject spawn;                //For EnemyManager
    public static bool levelOver;
    public int levelTwoCompleteScore = 40;

    Animator anim;                          // Reference to the animator component

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        levelOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player has run out of health...
        if (ScoreManager.score >= levelTwoCompleteScore)
        {
            LevelCompleteManager.win = true;
            anim.SetTrigger("LevelComplete");
            Invoke("Quit", 5f);
            levelOver = true;
            spawn.GetComponent<EnemyManager2>().CancelSpawn();   
        }
    }
    void Quit()
    {
        LevelCompleteManager.win = false;
        Application.Quit();
    }
}
