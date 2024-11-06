using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;
    public Text healthText;

    private void Update()
    {
        float currentHealth = playerHealth.GetCurrentHealth();
        healthSlider.value = currentHealth;
        healthText.text = $"Health: {currentHealth}/{playerHealth.maxHealth}";
    }
}