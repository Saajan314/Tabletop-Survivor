using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.TextCore.Text;
public class TileGenerator : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public GameObject whiteTilePrefab;
    public GameObject blackTilePrefab;
    public GameObject wallTilePrefab;
    public GameObject playerPrefab;
    public GameObject enemyPrefab; // Enemy prefab
    public int numberOfEnemies = 5; // Number of enemies to spawn

    private GameObject[,] grid;
    private List<Vector2Int> occupiedPositions = new List<Vector2Int>(); // Track occupied positions

    void Start()
    {
        grid = new GameObject[rows + 2, columns + 2];
        GenerateTiles();
        SpawnPlayer();
        SpawnEnemies();
    }

    void GenerateTiles()
    {
        for (int x = 0; x < rows + 2; x++)
        {
            for (int y = 0; y < columns + 2; y++)
            {
                GameObject tilePrefab = (x == 0 || x == rows + 1 || y == 0 || y == columns + 1) ? wallTilePrefab :
                                        (Random.value > 0.5f) ? whiteTilePrefab : blackTilePrefab;

                GameObject tile = Instantiate(tilePrefab, new Vector3(x, 0, y), Quaternion.identity);
                tile.name = $"Tile_{x}_{y}";
                grid[x, y] = tile;
            }
        }
        EnsurePath();
    }

    void SpawnPlayer()
    {
        int x = 1;
        int y = 1;
        GameObject player = Instantiate(playerPrefab, new Vector3(x, 0, y), Quaternion.identity);
        player.name = "Player";
        player.AddComponent<CameraFollow>();

        // Determine the color of the starting tile
        GameObject startingTile = grid[x, y];
        Color tileColor = startingTile.GetComponent<Renderer>().material.color;

        // Access the PlayerController and set the player's color to be the opposite of the tile color
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (tileColor == Color.white)
        {
            playerController.SetColor(playerController.blackFormColor);
        }
        else
        {
            playerController.SetColor(playerController.whiteFormColor);
        }

        // Add player's initial position to occupied positions
        occupiedPositions.Add(new Vector2Int(x, y));
    }

    void SpawnEnemies()
    {
        int enemiesSpawned = 0;

        while (enemiesSpawned < numberOfEnemies)
        {
            int x = Random.Range(1, rows + 1);
            int y = Random.Range(1, columns + 1);
            Vector2Int spawnPosition = new Vector2Int(x, y);

            // Check if the position is already occupied
            if (occupiedPositions.Contains(spawnPosition))
            {
                continue; // Skip to the next iteration if the position is occupied
            }

            GameObject tile = grid[x, y];
            Color tileColor = tile.GetComponent<Renderer>().material.color;

            // Instantiate the enemy at the selected position
            GameObject enemy = Instantiate(enemyPrefab, new Vector3(x, 0, y), Quaternion.identity);
            enemy.name = $"Enemy_{enemiesSpawned + 1}";

            // Set the enemy's color to be opposite of the tile's color
            Renderer enemyRenderer = enemy.GetComponent<Renderer>();
            if (tileColor == Color.white)
            {
                enemyRenderer.material.color = Color.black;
            }
            else
            {
                enemyRenderer.material.color = Color.white;
            }

            // Add position to the occupied list and increment enemy count
            occupiedPositions.Add(spawnPosition);
            enemiesSpawned++;
        }
    }

    void EnsurePath()
    {
        // Implement path-finding logic here to ensure connectivity
    }

    public GameObject GetTileAtPosition(Vector2Int position)
    {
        return grid[position.x, position.y];
    }

    public bool IsPositionOccupied(Vector2Int position)
    {
        return occupiedPositions.Contains(position);
    }

}








