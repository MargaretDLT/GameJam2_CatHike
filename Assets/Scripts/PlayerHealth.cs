using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = 0; // starting health
        healthBar.minValue = 0;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthBar.value = currentHealth;
    }
}
