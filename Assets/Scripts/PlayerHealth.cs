using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"Player starting health: {currentHealth}");
    }

    public void TakeDamage(int damage)
    {
        Debug.Log($"Player taking damage: {damage}. Current health: {currentHealth}");
        currentHealth -= damage;

        // Clamp health to zero to prevent negative values
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Player health after damage: {currentHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died.");
        // Instead of SetActive(false), you might want to:
        // - Show game over screen
        // - Restart level
        // - Play death animation
    }
}