using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    
    // Changed from Slider to Image
    public Image healthImage; 

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Max(currentHealth, 0f);

        UpdateHealthUI();

        if (currentHealth <= 0f)
            Die();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthUI();
    }

    private void Die()
    {
        PlayerDeath.instance.Die();
        currentHealth = maxHealth;
        UpdateHealthUI();
    }
    private void UpdateHealthUI()
    {
        if (healthImage != null)
        {
            healthImage.fillAmount = currentHealth / maxHealth;
        }
    }
}