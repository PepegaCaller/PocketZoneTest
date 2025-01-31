using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;

    [SerializeField]public int currentHealth;

    public GameObject healthBarUI;
    public Image healthBarFill;
    public Slider slider;

    public void TakeDamage(int damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth,
                                    0,
                                    maxHealth);

        UpdateHealthBar();
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private void UpdateHealthBar()
    {
        if (healthBarUI != null)
        {
            slider.value = currentHealth / (float)maxHealth;
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    public void Initialize()
    {
        currentHealth = maxHealth;
        if (healthBarUI != null)
        {
            UpdateHealthBar();
        }
    }
}
