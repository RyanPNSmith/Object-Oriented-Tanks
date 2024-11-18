using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth != null)
        {
            healthSlider.value = playerHealth.GetHealthPercentage();
        }
    }
}