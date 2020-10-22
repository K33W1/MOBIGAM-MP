using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class BulletMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 10f;

    private Rigidbody rb = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        LookAtVelocity();
    }

    public void Launch(Vector3 direction)
    {
        rb.velocity = direction * speed;
        LookAtVelocity();
    }

    private void LookAtVelocity()
    {
        if (rb.velocity.sqrMagnitude >= 1f)
            transform.rotation = Quaternion.LookRotation(rb.velocity);
    }
}
