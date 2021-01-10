using Kiwi.Events;
using UnityEngine;

[DisallowMultipleComponent]
public class SpikeManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent bossSpawned = null;

    [Header("References")]
    [SerializeField] private Cube cube = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float spawnRate = 0f;

    private bool isSpawning = true;
    private float timer = 0f;

    private void OnEnable()
    {
        bossSpawned.RegisterListener(StopSpawning);
    }

    private void Update()
    {
        if (!isSpawning)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            timer -= spawnRate;
            SpawnTower();
        }
    }

    private void SpawnTower()
    {
        Spike spike = SpikePooler.Instance.GetPooledObject();
        Vector3 spawnPoint = cube.GetRandomPointInside();

        spike.Initialize(spawnPoint);
    }

    private void StopSpawning()
    {
        isSpawning = false;
    }

    private void OnDisable()
    {
        bossSpawned.UnregisterListener(StopSpawning);
    }
}