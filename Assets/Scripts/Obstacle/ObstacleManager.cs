using UnityEngine;

[DisallowMultipleComponent]
public class ObstacleManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Cube cube = null;
    [SerializeField] private ObstacleSettings[] allSettings = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float spawnRate = 4f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            timer -= spawnRate;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        Obstacle obstacle = ObstaclePooler.Instance.GetPooledObject();
        Vector3 randomSpawnPoint = cube.GetRandomPointInside();

        obstacle.transform.position = randomSpawnPoint;
        obstacle.Spawn(allSettings.GetRandom(), Vector3.back);
    }
}
