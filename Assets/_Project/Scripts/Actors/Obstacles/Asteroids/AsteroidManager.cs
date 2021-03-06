﻿using Kiwi.Events;
using Kiwi.Extensions;
using UnityEngine;

[DisallowMultipleComponent]
public class AsteroidManager : MonoBehaviour
{
    [Header("Game Events")]
    [SerializeField] private GameEvent bossSpawned = null;

    [Header("References")]
    [SerializeField] private Cube cube = null;
    [SerializeField] private ObstacleConfig[] allSettings = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float spawnRate = 4f;

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
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Asteroid asteroid = AsteroidPooler.Instance.GetPooledObject();
        Vector3 randomSpawnPoint = cube.GetRandomPointInside();

        asteroid.transform.position = randomSpawnPoint;
        asteroid.Spawn(allSettings.GetRandom(), Vector3.back);
    }

    public void StartSpawning()
    {
        isSpawning = true;
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }

    private void OnDisable()
    {
        bossSpawned.UnregisterListener(StopSpawning);
    }
}
