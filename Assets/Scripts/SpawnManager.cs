using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] keyPrefabs; // Array of key prefabs (key1, key2, key3)
    public Transform[] spawnPoints; // Array of spawn points in the maze

    public int numberOfKeys = 3; // Number of keys to spawn

    void Start()
    {
        SpawnKeys();
    }

    void SpawnKeys()
    {
        for (int i = 0; i < numberOfKeys; i++)
        {
            // Randomly select a key prefab
            GameObject randomKeyPrefab = keyPrefabs[Random.Range(0, keyPrefabs.Length)];

            // Randomly select a spawn point
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instantiate the selected key prefab at the random spawn point
            Instantiate(randomKeyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
