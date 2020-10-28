using UnityEngine;

[DisallowMultipleComponent]
public class EnemyWaypointFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float speed = 0.1f;

    public Transform waypoint = null;

    private void OnEnable()
    {
        waypoint = EnemyWaypoints.Instance.GetWaypoint();
    }

    private void Update()
    {
        if (waypoint != null)
        {
            transform.position = Vector3.Lerp(transform.position, waypoint.position, speed);
        }
    }

    private void OnDisable()
    {
        if (waypoint != null)
        {
            EnemyWaypoints.Instance.ReturnWaypoint(waypoint);
            waypoint = null;
        }
    }
}
