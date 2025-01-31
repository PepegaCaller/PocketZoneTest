using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    public GameObject healthBarUI;
    public Image healthBarFill;
    public Slider slider;

    [SerializeField] private int _maxHealth = 20;
    [SerializeField] private int _currentHealth;
    [SerializeField] private GameObject _loot;

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Clamp(_currentHealth,
                                    0,
                                    _maxHealth);

        UpdateHealthBar();
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        if (healthBarUI != null)
        {
            slider.value = _currentHealth / (float)_maxHealth;
        }
    }

     public void Start()
    {
        Debug.Log("Health");
        _currentHealth = _maxHealth;
        if (healthBarUI != null)
        {
            UpdateHealthBar();
        }
    }
    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(_loot, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
