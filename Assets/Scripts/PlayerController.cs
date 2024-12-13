using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Color whiteFormColor = Color.white;
    public Color blackFormColor = Color.black;
    public float moveSpeed = 5f;
    private Vector2Int gridPosition;
    private Color currentColor;
    private TileGenerator tileGenerator; // Reference to TileGenerator

    void Start()
    {
        tileGenerator = FindObjectOfType<TileGenerator>(); // Get reference to TileGenerator
        gridPosition = new Vector2Int((int)transform.position.x, (int)transform.position.z);
    }

    void Update()
    {
        HandleMovement();
        HandleColorSwitch();
    }

    void HandleMovement()
    {
        Vector2Int moveDirection = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.W)) moveDirection = Vector2Int.up;
        else if (Input.GetKeyDown(KeyCode.S)) moveDirection = Vector2Int.down;
        else if (Input.GetKeyDown(KeyCode.A)) moveDirection = Vector2Int.left;
        else if (Input.GetKeyDown(KeyCode.D)) moveDirection = Vector2Int.right;

        if (moveDirection != Vector2Int.zero)
        {
            Vector2Int targetPosition = gridPosition + moveDirection;

            // Check if target position is valid for movement
            if (IsMoveAllowed(targetPosition))
            {
                gridPosition = targetPosition;
                transform.position = new Vector3(gridPosition.x, 0, gridPosition.y);
            }
        }
    }

    bool IsMoveAllowed(Vector2Int targetPosition)
    {
        // Check if target position is within bounds
        if (targetPosition.x < 1 || targetPosition.x > tileGenerator.rows ||
            targetPosition.y < 1 || targetPosition.y > tileGenerator.columns)
        {
            return false; // Out of bounds
        }

        // Check if target position is occupied by an enemy
        if (tileGenerator.IsPositionOccupied(targetPosition))
        {
            return false; // Enemy on target tile
        }

        // Check if target position is a tile of the correct color
        GameObject targetTile = tileGenerator.GetTileAtPosition(targetPosition);
        Color tileColor = targetTile.GetComponent<Renderer>().material.color;

        if ((currentColor == whiteFormColor && tileColor == Color.white) ||
            (currentColor == blackFormColor && tileColor == Color.black))
        {
            return false; // Same color tile, movement not allowed
        }

        return true; // Move is allowed
    }

    void HandleColorSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Switch between white and black form colors
            if (currentColor == whiteFormColor)
            {
                SetColor(blackFormColor);
            }
            else
            {
                SetColor(whiteFormColor);
            }
        }
    }

    public void SetColor(Color color)
    {
        currentColor = color;
        GetComponent<Renderer>().material.color = color;
    }
}



