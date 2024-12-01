using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // Action callback for when the player dies
    public static Action OnPlayerDeath;

    void Start()
    {
        currentHealth = maxHealth;
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
        gameObject.SetActive(false);
    }

    public float GetHealthPercentage()
    {
        return (float)currentHealth / maxHealth;
    }
}
