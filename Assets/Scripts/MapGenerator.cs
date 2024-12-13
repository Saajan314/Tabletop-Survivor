using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public GameObject obstaclePrefab;
    public GameObject blueCubePrefab;  // Reference to the blue cube prefab
    public int centralTileCount = 5;   // Core central tiles
    public int outerTileCount = 10;    // Additional tiles per level
    public int difficultyLevel = 1;
    public int blueCubesToCollect = 5; // Number of blue cubes to collect before progressing
    public int collectedBlueCubes = 0; // Track collected blue cubes

    private List<Vector3> generatedTiles = new List<Vector3>();

    void Start()
    {
        GenerateLevel();
    }

    void GenerateLevel()
    {
        generatedTiles.Clear();
        CreateCentralCluster();

        // Expand outward with controlled randomness
        for (int i = 0; i < outerTileCount + (difficultyLevel * 5); i++)
        {
            Vector3 newTilePosition = GetRandomAdjacentPosition();
            if (!generatedTiles.Contains(newTilePosition))
            {
                generatedTiles.Add(newTilePosition);
                Instantiate(tilePrefab, newTilePosition, Quaternion.identity);

                // Place obstacles with increasing difficulty
                if (Random.value < 0.3f + (difficultyLevel * 0.05f))
                {
                    Instantiate(obstaclePrefab, newTilePosition, Quaternion.identity);
                }

                // Randomly place blue cubes
                if (Random.value < 0.1f)  // Adjust chance of blue cubes spawning
                {
                    Instantiate(blueCubePrefab, newTilePosition, Quaternion.identity);
                }
            }
        }
    }

    void CreateCentralCluster()
    {
        Vector3 startPosition = Vector3.zero;
        generatedTiles.Add(startPosition);
        Instantiate(tilePrefab, startPosition, Quaternion.identity);

        // Form the initial cluster around the center
        Vector3[] initialDirections = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        foreach (Vector3 direction in initialDirections)
        {
            Vector3 newPosition = startPosition + direction;
            generatedTiles.Add(newPosition);
            Instantiate(tilePrefab, newPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomAdjacentPosition()
    {
        // Choose a random tile from existing ones to expand from
        Vector3 baseTile = generatedTiles[Random.Range(0, generatedTiles.Count)];
        Vector3[] possibleDirections = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 direction = possibleDirections[Random.Range(0, possibleDirections.Length)];
        return baseTile + direction;
    }

    public void IncreaseDifficulty()
    {
        difficultyLevel++;
        GenerateLevel();
    }

    // Call this function to track when the player collects a blue cube
    public void CollectBlueCube()
    {
        collectedBlueCubes++;
        if (collectedBlueCubes >= blueCubesToCollect)
        {
            ProceedToNextLevel();
        }
    }

    // Move to the next level
    void ProceedToNextLevel()
    {
        IncreaseDifficulty();
        collectedBlueCubes = 0; // Reset the collected cubes count
    }
}



