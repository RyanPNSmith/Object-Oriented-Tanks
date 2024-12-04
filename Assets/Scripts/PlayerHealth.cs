using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private PlayerLives playerLives; // Reference to PlayerLives

    // Action callback for when the player dies
    public static Action OnPlayerDeath;

    void Start()
    {
        currentHealth = maxHealth;
        playerLives = GetComponent<PlayerLives>(); // Get the PlayerLives component
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
        OnPlayerDeath?.Invoke(); // Trigger the death event
        playerLives.LoseLife(); // Lose a life when the player dies

        // Reset health to maximum after losing a life
        currentHealth = maxHealth; // Reset health after losing a life
        Debug.Log($"Player health reset to {currentHealth}");
        Debug.Log($"Current Lives after death: {playerLives.GetCurrentLives()}");
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Player healed by {amount}. Current health: {currentHealth}");
    }

    public float GetHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }
}
