using System.Collections;
using UnityEngine;
using TMPro;  // Use TextMeshPro

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 60f; // Time limit in seconds (for countdown)
    private float currentTime; // The current time, initialized to the time limit

    public TextMeshProUGUI timerText; // Reference to the UI TextMeshPro component
    public GameObject winScreen; // Reference to the Win Screen Canvas/GameObject
    public GameObject defeatScreen;

    public bool hasWon = false; // Flag to check if the player has won

    void Start()
    {
        currentTime = timeLimit; // Initialize the current time with the time limit
        UpdateTimerDisplay(); // Display the initial time

        // Make sure the win screen is initially inactive
        winScreen.SetActive(false);
    }

    void Update()
    {
        if (!hasWon) // Only update the timer if the player hasn't won yet
        {
            // Decrease the current time by the time passed since the last frame
            currentTime -= Time.deltaTime;

            // If the current time drops below zero, set it to zero
            if (currentTime < 0)
            {
                currentTime = 0;
                PlayerWins(); // Call the win method if time runs out
            }

            // Format the time as minutes and seconds
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            // Update the UI with the formatted time
            UpdateTimerDisplay(minutes, seconds);
        }
    }

    void UpdateTimerDisplay(int minutes = 0, int seconds = 0)
    {
        // Update the UI TextMeshPro component to display the remaining time
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void PlayerWins()
    {
        // The player wins when the timer reaches zero
        hasWon = true;

        // Display a win message and show the win screen
        timerText.text = "You Win!";
        winScreen.SetActive(true); // Show the win screen
        Debug.Log("You Win!");

        // You can add additional code here to stop the game or show a win screen
    }

    void PlayerLoses()
    {
        hasWon = false;

        defeatScreen.SetActive(true);

    }
}



