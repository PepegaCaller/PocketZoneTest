using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public int enemyCount = 3; 
    public float spawnRange = 10f;

    public void Initialize()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range(-spawnRange, spawnRange),
                Random.Range(-spawnRange, spawnRange), 
                0);
            Instantiate(enemyPrefab, randomPosition, Quaternion.identity);

        }
    }
}
