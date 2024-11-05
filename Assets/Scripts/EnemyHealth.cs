using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Variables for maximum and current health
    public int maxHealth = 100;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize current health to max health at the start
        currentHealth = maxHealth;
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        Debug.Log($"Taking damage: {damage}. Current health: {currentHealth}"); // Log when taking damage
        currentHealth -= damage;

        // Clamp health to zero to prevent negative values
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Health after damage: {currentHealth}"); // Log health after damage

        // Check if health reaches zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Method to handle death
    private void Die()
    {
        Debug.Log("Enemy has died.");
        gameObject.SetActive(false);
    }

    // Method to get current health
    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}

