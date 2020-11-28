using UnityEngine;

[DisallowMultipleComponent]
public class BossMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform waypoint = null;

    [Header("Settings")]
    [SerializeField] private float maxSpeed = 1f;
    [SerializeField] private float smoothing = 3f;

    private void Update()
    {
        Vector3 diff = waypoint.position - transform.position;
        Vector3 rawMove = diff * smoothing * Time.deltaTime;
        Vector3 move = Vector3.ClampMagnitude(rawMove, maxSpeed);

        transform.position += move;
    }
}
