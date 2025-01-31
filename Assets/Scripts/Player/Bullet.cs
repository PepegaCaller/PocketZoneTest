using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;   // ����, ������� ������� ����
    public float lifetime = 3f; // ����� ����� ����

    void Start()
    {
        // ���������� ���� ����� ��������� �����
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("1");
        // ���������, ����������� �� ���� � ������
        if (collision.CompareTag("Enemy"))
        {
            // �������� ��������� ����� � ������� ����
            MonsterHealth enemy = collision.GetComponent<MonsterHealth>();
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage); // ������� ����
            }

            // ���������� ���� ����� ���������
            Destroy(gameObject);
        }
    }
    
}