using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab; // Reference to the gem prefab
    public int numberOfGems = 5; // Number of gems to spawn
    public float spawnAreaWidth = 10f; // Width of the spawn area
    public float spawnAreaHeight = 10f; // Height of the spawn area

    void Start()
    {
        // Spawn the gems at the start of the game
        SpawnGems();
    }

    void SpawnGems()
    {
        for (int i = 0; i < numberOfGems; i++)
        {
            // Randomly generate a position within the spawn area
            float x = Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2);
            float y = Random.Range(-spawnAreaHeight / 2, spawnAreaHeight / 2);
            Vector3 spawnPosition = new Vector3(x, y, 0);

            // Instantiate the gem at the generated position
            Instantiate(gemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}

