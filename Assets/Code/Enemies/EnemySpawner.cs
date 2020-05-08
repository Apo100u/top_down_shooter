using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float spawnCooldown = 5f;
    [SerializeField] private GameObjectPool enemyPool;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Vector3[] spawnPositions;

    private float timer = 0;
    private Enemy spawnedEnemy;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnCooldown)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        spawnPoint.position = spawnPositions[Random.Range(0, spawnPositions.Length)];

        spawnedEnemy = enemyPool.Take().GetComponent<Enemy>();

        if (!spawnedEnemy.Initialized)
        {
            spawnedEnemy.Init(player, enemyPool);
        }

        spawnedEnemy.GetComponent<Health>().SetAsMax();
    }
}