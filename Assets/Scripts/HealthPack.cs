using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public int healAmount = 20; // Amount of health to restore

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Collided with: {other.name}"); // Log the name of the colliding object
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Debug.Log("Health pack collected by player.");
                Destroy(gameObject); // Destroy the health pack after use
            }
            else
            {
                Debug.Log("PlayerHealth component not found on player."); // Log if component is missing
            }
        }
        else if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.Heal(healAmount);
                Debug.Log("Health pack collected by enemy.");
                Destroy(gameObject); // Destroy the health pack after use
            }
        }
    }
} 