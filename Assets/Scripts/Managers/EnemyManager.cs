using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.   

    public GameObject ZomBunny;
    public GameObject ZomBear;

    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        // Spawns both zombear and zombunny simultaneously and their respective spawn points
        InvokeRepeating("SpawnBunny", 3f, 3f);
        InvokeRepeating("SpawnBear", 3f, 3f);
        InvokeRepeating("SpawnBearTwo", 3f, 6f);
        InvokeRepeating("SpawnBunnyTwo", 6f, 6f);
    }

    public void SpawnBunny()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        /* Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);*/

        // Create an instance of the ZomBunny enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(ZomBunny, spawnPoints[0].position, spawnPoints[0].rotation);
    }

    void SpawnBear()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        /* Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);*/

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        Instantiate(ZomBear, spawnPoints[1].position, spawnPoints[0].rotation);
    }

    void SpawnBearTwo()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Create an instance of the enemy prefab at specific position and rotation
        Instantiate(ZomBear, spawnPoints[2].position, spawnPoints[0].rotation);
    }

    void SpawnBunnyTwo()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Create an instance of the enemy prefab at specific position and rotation
        Instantiate(ZomBunny, spawnPoints[2].position, spawnPoints[0].rotation);
    }

    public void CancelSpawn()
    {
        CancelInvoke();
    }
}
