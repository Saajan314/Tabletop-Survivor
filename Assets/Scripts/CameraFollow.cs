using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // Reference to the player's Transform
    public Vector3 offset;    // Offset from the player (e.g., distance behind and above)

    public float smoothSpeed = 0.125f;  // Speed of camera smoothing

    void Start()
    {
        // Set initial camera position to the player position + the offset
        transform.position = player.position + offset;
    }

    void Update()
    {
        // Set target position (player position with offset)
        Vector3 targetPosition = player.position + offset;

        // Smoothly move towards the target position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Update camera position
        transform.position = smoothedPosition;
    }
}
