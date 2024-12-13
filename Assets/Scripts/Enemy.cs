using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab;  // The prefab used to create projectiles
    public float fireRate = 2f;          // Time interval between shots
    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            FireProjectiles();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireProjectiles()
    {
        Vector3[] directions = {
            Vector3.forward,
            Vector3.back,
            Vector3.left,
            Vector3.right
        };

        // Iterate through the directions and fire projectiles
        foreach (Vector3 direction in directions)
        {
            // Instantiate the projectile prefab
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Initialize the projectile's direction using the SetDirection method
            projectile.GetComponent<Projectile>().SetDirection(direction);
        }
    }
}



