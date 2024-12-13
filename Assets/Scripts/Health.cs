using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Use this if you're using TextMeshPro

public class Health : MonoBehaviour
{
    public int maxHealth = 100;  // The player's maximum health
    public int currentHealth;

    public TextMeshProUGUI healthText;  // Reference to the UI Text component

    void Start()
    {
        currentHealth = maxHealth;  // Initialize health at the start
        UpdateHealthDisplay();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // Decrease health by the damage amount
        currentHealth = Mathf.Max(currentHealth, 0);  // Ensure health doesn't go below 0
        Debug.Log("Health after damage: " + currentHealth);  // Debug line to track health changes
        UpdateHealthDisplay();

        if (currentHealth == 0)
        {
            // Handle player death (e.g., Game Over)
            Debug.Log("Player is dead!");
        }
    }
/*


    public void Heal(int healAmount)
    {
        currentHealth += healAmount;  // Increase health by the heal amount
        currentHealth = Mathf.Min(currentHealth, maxHealth);  // Ensure health doesn't exceed max
        UpdateHealthDisplay();
    }*/

    void UpdateHealthDisplay()
    {
        healthText.text = "Health: " + currentHealth + "/" + maxHealth;  // Update the UI text
    }


}

