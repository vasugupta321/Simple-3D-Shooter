using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManagerLevelTwo : MonoBehaviour
{
    public static bool gameOver;
    public PlayerHealth playerHealth;       // Reference to the player's health.
    public float restartDelay = 3f;         // Time to wait before restarting the level


    Animator anim;                          // Reference to the animator component.
    float restartTimer;                     // Timer to count up to restarting the level

    void Awake()
    {
        // Set up the reference.
        anim = GetComponent<Animator>();
        gameOver = false;
    }


    void Update()
    {
        // If the player has run out of health...
        if (playerHealth.currentHealth <= 0)
        {
            // ... tell the animator the game is over.
            anim.SetTrigger("GameOver");
            gameOver = true;


            // .. increment a timer to count up to restarting.
            restartTimer += Time.deltaTime;

            // .. if it reaches the restart delay...
            if (restartTimer >= restartDelay)
            {
                /* .. then reload the currently loaded level.
                 * The below can also be used to restart the level/scene but SceneManager is more reliable
                //Application.LoadLevel(Application.loadedLevel);
                /playerHealth.RestartLevel();*/

                SceneManager.LoadScene("Level 02");
            }
        }
    }
}
