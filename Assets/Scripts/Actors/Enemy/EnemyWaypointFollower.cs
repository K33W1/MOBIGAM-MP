using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Enemy))]
public class EnemyWaypointFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float speed = 0.1f;

    private Enemy enemy = null;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Transform waypoint = enemy.Waypoint;

        if (waypoint != null)
        {
            transform.position = Vector3.Lerp(transform.position, waypoint.position, speed);
        }
    }
}
