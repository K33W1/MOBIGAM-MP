using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class ObstacleMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField, Min(0)] private float minSpeed = 0.1f;
    [SerializeField, Min(0)] private float maxSpeed = 100f;

    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Vector3 direction)
    {
        float randomSpeed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = direction * randomSpeed;
    }
}
