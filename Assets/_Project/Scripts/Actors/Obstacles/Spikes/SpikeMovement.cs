using UnityEngine;

[DisallowMultipleComponent]
public class SpikeMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform visualsTransform = null;

    [Header("Settings")]
    [SerializeField, Min(0)] private float speed = 10f;
    [SerializeField, Min(0)] private float popupSpeed = 1f;

    private Rigidbody rb = null;

    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        visualsTransform.localPosition = Vector3.Lerp(
            visualsTransform.localPosition,
            Vector3.zero,
            popupSpeed * Time.fixedDeltaTime);
        rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
    }

    public void Initialize(Vector3 direction)
    {
        velocity = direction * speed;
        visualsTransform.localPosition = visualsTransform.up * -100f;
    }
}
