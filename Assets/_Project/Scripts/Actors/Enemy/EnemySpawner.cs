using System.Collections;
using UnityEngine;

[DisallowMultipleComponent]
public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private EnemyAPooler enemyAPooler = null;
    [SerializeField] private EnemyBPooler enemyBPooler = null;
    [SerializeField] private EnemyCPooler enemyCPooler = null;
    [SerializeField] private Transform[] spawnLocations = null;
    [SerializeField] private IntValue enemyCountObject = null;

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

            Enemy enemy = null;
            int random = Random.Range(0, 2);

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

            enemyCountObject.Value++;

            yield return spawnWait;
        }
    }
}
