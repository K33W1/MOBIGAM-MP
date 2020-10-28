using UnityEngine;

[DisallowMultipleComponent]
public class EnemyWaypointFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float speed = 0.1f;

    private Transform pointToFollow = null;

    private void OnEnable()
    {
        pointToFollow = EnemyWaypoints.Instance.GetPosition();
    }

    private void Update()
    {
        if (pointToFollow != null)
        {
            transform.position = Vector3.Lerp(transform.position, pointToFollow.position, speed);
        }
    }

    private void OnDisable()
    {
        EnemyWaypoints.Instance?.ReturnPosition(pointToFollow);
    }
}
