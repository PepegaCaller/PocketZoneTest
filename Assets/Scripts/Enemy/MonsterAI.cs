
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float attackRange = 1f;
    public float moveSpeed = 3f;
    public float attackCooldown = 2f;
    public int damage = 10;
    public int health = 20;

    private Transform player;
    private float lastAttackTime = 0f;
    private void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position,
                                                 player.position,
                                                 moveSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        
        if (Time.time >= lastAttackTime + attackCooldown)
        {

            lastAttackTime = Time.time;
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
    public void Start()
    {
        Debug.Log("AI Start");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Update()
    {
        if (player == null) return;
        float distanceToPlayer = Vector2.Distance(transform.position,
                                                  player.position);
        if (distanceToPlayer<= detectionRadius && distanceToPlayer > attackRange)
        {
            MoveTowardsPlayer();
        }
        else if (distanceToPlayer <= attackRange)
        {
            AttackPlayer();
        }
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}
