using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemyPooler enemyPooler = null;
    [SerializeField] private Transform[] spawnLocations = null;
    [SerializeField] private IntValue enemyCountObject = null;

    [Header("Enemy Dependencies")]
    [SerializeField] private Transform player = null;

    [Header("Settings")]
    [SerializeField] private int maxSpawnCount = 8;
    [SerializeField] private int maxEnemyCount = 4;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnRate = 1f;

    private void Start()
    {
        enemyCountObject.Value = 0;

        foreach (Enemy enemy in transform.GetComponentsInChildren<Enemy>())
        {
            if (enemy.gameObject.activeSelf)
            {
                enemyCountObject.Value++;
            }

            enemy.Initialize(player);
        }

        StartCoroutine(SpawningLoop());
    }

    private IEnumerator SpawningLoop()
    {
        yield return new WaitForSeconds(startDelay);

        WaitForSeconds spawnWait = new WaitForSeconds(spawnRate);

        while (true)
        {
            Transform randomLocation = spawnLocations[Random.Range(0, spawnLocations.Length)];
            Vector3 spawnPos = randomLocation.position;

            while (enemyCountObject.Value >= maxEnemyCount)
                yield return 0;

            Element randomElement = ElementExtensions.GetRandomValidElement();
            Enemy enemy = enemyPooler.GetPooledObject();

            enemy.transform.position = spawnPos;
            enemy.Initialize(player);
            enemy.InitializeOnSpawn(randomElement);

            enemyCountObject.Value++;

            yield return spawnWait;
        }
    }
}
