using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    // This script handles the gem collection.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerGemManager gemManager = other.GetComponent<PlayerGemManager>();
            if (gemManager != null)
            {
                gemManager.CollectGem();
            }

            // Destroy the gem after collection
            Destroy(gameObject);
        }
    }
}

