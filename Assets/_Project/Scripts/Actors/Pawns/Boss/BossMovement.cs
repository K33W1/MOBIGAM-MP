using UnityEngine;

[DisallowMultipleComponent]
public class BossMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float smoothing = 3f;

    private Transform waypoint = null;

    public void Initialize(Transform waypoint)
    {
        this.waypoint = waypoint;
    }
 
    private void Update()
    {
        Vector3 diff = waypoint.position - transform.position;
        Vector3 rawMove = diff * smoothing * Time.deltaTime;
        Vector3 move = Vector3.ClampMagnitude(rawMove, maxSpeed);

        transform.position += move;
    }
}
