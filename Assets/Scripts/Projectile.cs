using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 3f;
    private Vector3 direction;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy projectile after a set time
    }

    void Update()
    {
        // Move the projectile in the assigned direction
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the projectile collides with the player
        if (other.CompareTag("Player"))
        {
            // Get the Health script attached to the player and subtract 10 health
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(10); // Apply 10 damage
            }

            Destroy(gameObject); // Destroy the projectile after it hits the player
        }
        else if (other.CompareTag("Wall"))
        {
            Destroy(gameObject); // Destroy projectile upon hitting walls
        }
    }
}










