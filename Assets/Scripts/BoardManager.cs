using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject floorTile;
    public GameObject obstacleTile;
    public int columns = 8;
    public int rows = 8;
    public float tileSpacing = 1.1f;

    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                Vector3 position = new Vector3(x * tileSpacing, 0, y * tileSpacing);
                Instantiate(floorTile, position, Quaternion.identity, transform);

                if (Random.value < 0.2f) // 20% chance for obstacle
                {
                    Instantiate(obstacleTile, position, Quaternion.identity, transform);
                }
            }
        }
    }
}

