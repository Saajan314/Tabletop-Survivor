using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGemManager : MonoBehaviour
{
    public int gemCount = 0; // The player's current gem count
    public Text gemCountText; // The UI Text to display the gem count

    void Start()
    {
        // Initialize the gem count display
        UpdateGemCountUI();
    }

    public void CollectGem()
    {
        // Increase gem count when a gem is collected
        gemCount++;

        // Update the UI to reflect the new gem count
        UpdateGemCountUI();
    }

    void UpdateGemCountUI()
    {
        // Update the UI text with the current gem count
        gemCountText.text = "Gems: " + gemCount.ToString();
    }
}

