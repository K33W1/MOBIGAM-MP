using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy References")]
    [SerializeField] private EnemyPooler enemyAPooler = null;
    [SerializeField] private EnemyPooler enemyBPooler = null;
    [SerializeField] private EnemyPooler enemyCPooler = null;
    [SerializeField] private Boss boss = null;

    [Header("References")]
    [SerializeField] private Transform[] spawnLocations = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private int maxEnemiesAlive = 4;
    [SerializeField, Min(0)] private int enemiesUntilBoss = 10;
    [SerializeField, Min(0)] private float startDelay = 2f;
    [SerializeField, Min(0)] private float spawnRate = 1f;

    private bool hasBossSpawned = false;
    private int totalEnemiesSpawned = 0;
    private int totalEnemiesDied = 0;
    private int enemiesAlive = 0;

    private void Start()
    {
        boss.Despawn();

        foreach (Enemy enemy in transform.GetComponentsInChildren<Enemy>(true))
        {
            if (enemy.gameObject.activeSelf)
            {
                enemiesAlive++;
            }

            Health health = enemy.GetComponent<Health>();
            health.Died += OnEnemyDeath;
        }

        if (enemiesUntilBoss > 0)
        {
            StartCoroutine(SpawningLoop());
        }
        else
        {
            boss.Spawn();
            hasBossSpawned = true;
        }
    }

    private void OnEnemyDeath()
    {
        enemiesAlive--;
        totalEnemiesDied++;

        if (!hasBossSpawned && totalEnemiesDied >= enemiesUntilBoss)
        {
            boss.Spawn();
            hasBossSpawned = true;
        }
    }

    private IEnumerator SpawningLoop()
    {
        yield return new WaitForSeconds(startDelay);

        WaitForSeconds spawnWait = new WaitForSeconds(spawnRate);

        while (totalEnemiesSpawned < enemiesUntilBoss)
        {
            while (enemiesAlive >= maxEnemiesAlive)
            {
                yield return 0;
            }

            SpawnEnemy();

            enemiesAlive++;
            totalEnemiesSpawned++;

            yield return spawnWait;
        }
    }

    private void SpawnEnemy()
    {
        Transform randomLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
        Vector3 spawnPos = randomLocation.position;
        int random = Random.Range(0, 3);
        Enemy enemy = null;

        if (random == 0)
        {
            enemy = enemyAPooler.GetPooledObject();
        }
        else if (random == 1)
        {
            enemy = enemyBPooler.GetPooledObject();
        }
        else
        {
            enemy = enemyCPooler.GetPooledObject();
        }

        enemy.transform.position = spawnPos;
        enemy.Spawn();
    }
}
