using UnityEngine;

public class EnemyManager2 : MonoBehaviour
{
    public GameObject stopSpawn;
    public PlayerHealth playerHealth;       // Reference to the player's heatlh.   

    public GameObject ZomBear;
    public GameObject Hellephant;

    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        // Spawns both zombear and zombunny simultaneously and their respective spawn points
        InvokeRepeating("SpawnBear", 3f, 3f);
        InvokeRepeating("SpawnHellephant", 3f, 3f);
        InvokeRepeating("SpawnHellephantTwo", 3f, 6f);
        InvokeRepeating("SpawnBearTwo", 6f, 6f);
    }

    public void SpawnBear()
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
        Instantiate(ZomBear, spawnPoints[0].position, spawnPoints[0].rotation);
    }

    void SpawnHellephant()
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

    void SpawnHellephantTwo()
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

    void SpawnBearTwo()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0f)
        {
            // ... exit the function.
            return;
        }

        // Create an instance of the enemy prefab at specific position and rotation
        Instantiate(Hellephant, spawnPoints[2].position, spawnPoints[0].rotation);
    }

    public void CancelSpawn()
    {
        CancelInvoke();
    }
}
