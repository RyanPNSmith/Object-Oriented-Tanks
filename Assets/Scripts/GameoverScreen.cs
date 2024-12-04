using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; // Assign in Inspector
    private int remainingEnemies;

    void Start()
    {
        // Hide the Game Over Canvas at the start
        gameOverCanvas.SetActive(false);

        // Count all enemies in the scene
        remainingEnemies = FindObjectsOfType<EnemyHealth>().Length;

        // Subscribe to events
        PlayerHealth.OnPlayerDeath += HandlePlayerDeath;
        EnemyHealth.OnEnemyDeath += HandleEnemyDeath;
    }

    private void HandlePlayerDeath()
    {
        var playerLives = FindObjectOfType<PlayerLives>(); // Safely get the PlayerLives component
        if (playerLives != null && playerLives.GetCurrentLives() > 0)
        {
            // Don't trigger game over if the player has remaining lives
            return;
        }

        ShowGameOverCanvas();
    }


    private void HandleEnemyDeath()
    {
        remainingEnemies--;
        Debug.Log($"Enemy died. Remaining enemies: {remainingEnemies}");

        if (remainingEnemies <= 0)
        {
            Debug.Log("All enemies defeated. Game over triggered.");
            ShowGameOverCanvas();
        }
    }


    public void ShowGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }


    public void RestartGame()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Reset time scale
        SceneManager.LoadScene(0); // Assumes the main menu is scene 0 in Build Settings
    }

    private void OnDestroy()
    {
        // Unsubscribe from events to avoid memory leaks
        PlayerHealth.OnPlayerDeath -= HandlePlayerDeath;
        EnemyHealth.OnEnemyDeath -= HandleEnemyDeath;
    }
}
