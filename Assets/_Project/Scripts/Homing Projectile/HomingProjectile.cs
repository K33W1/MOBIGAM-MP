using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class HomingProjectile : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float force = 10f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float maxSpeed = 50f;
    [SerializeField] private float startingSpeed = 1f;
    [SerializeField] private float startHomingDelay = 2f;

    private Rigidbody rb = null;
    private Transform target = null;

    private bool isHoming = false;
    private float timer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch(Transform origin, Transform target)
    {
        transform.position = origin.position;
        transform.rotation = origin.rotation;

        this.target = target;
        rb.velocity = origin.forward * startingSpeed;
        isHoming = false;
        timer = 0f;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= startHomingDelay)
        {
            isHoming = true;
        }

        if (isHoming)
        {
            Vector3 diff = target.position - transform.position;
            Vector3 dir = diff.normalized;

            // Acceleration
            rb.velocity += transform.forward * force * Time.fixedDeltaTime;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            rb.velocity = Vector3.RotateTowards(rb.velocity, dir, rotationSpeed * Time.fixedDeltaTime, 0f);
        }

        rb.rotation = Quaternion.LookRotation(rb.velocity);
    }

    private void OnDisable()
    {
        HomingProjectilePooler.Instance.ReturnToPool(this);
    }
}
