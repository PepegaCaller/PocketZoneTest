using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;   // Урон, который наносит пуля
    public float lifetime = 3f; // Время жизни пули

    void Start()
    {
        // Уничтожаем пулю через некоторое время
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("1");
        // Проверяем, столкнулась ли пуля с врагом
        if (collision.CompareTag("Enemy"))
        {
            // Получаем компонент врага и наносим урон
            MonsterHealth enemy = collision.GetComponent<MonsterHealth>();
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage); // Наносим урон
            }

            // Уничтожаем пулю после попадания
            Destroy(gameObject);
        }
    }
    
}