using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    public int totalLives = 2; // Total number of lives
    private int currentLives;

    public TMP_Text lifeCounterText; // Reference to the TextMeshPro component for displaying lives

    void Start()
    {
        currentLives = totalLives; // Initialize current lives
        UpdateLifeCounter(); // Update the UI at the start
    }

    public void LoseLife()
    {
        // Check if the player has lives left before decrementing
        if (currentLives > 0)
        {
            currentLives--;
            Debug.Log($"Life lost! Current lives: {currentLives}");

            // Update the UI when a life is lost
            UpdateLifeCounter(); 

            // Check if the player has no lives left after losing one
            if (currentLives <= 0)
            {
                currentLives = 0; // Ensure the counter is set to zero
                UpdateLifeCounter(); // Update the UI to show zero lives
                GameOver(); // Call GameOver method to trigger game over screen
            }
        }
    }

    public void ResetLives()
    {
        currentLives = totalLives; // Reset lives to total
        UpdateLifeCounter(); // Update the UI when lives are reset
    }

    private void GameOver()
    {
        var gameOverManager = FindObjectOfType<GameOverManager>();
        if (gameOverManager != null)
        {
            gameOverManager.ShowGameOverCanvas(); // Show the game over screen
        }
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    private void UpdateLifeCounter()
    {
        if (lifeCounterText != null)
        {
            lifeCounterText.text = $"Lives: {currentLives}"; // Update the text to show current lives
        }
    }
}
