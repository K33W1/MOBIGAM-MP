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
    private Health health = null;
    private DamageOtherOnCollision damageOtherOnCollision = null;

    private Vector3 velocity = Vector3.zero;
    private bool isShattering = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
        damageOtherOnCollision = GetComponent<DamageOtherOnCollision>();
    }

    private void OnEnable()
    {
        health.Died += OnDeathOrDamagedOther;
        damageOtherOnCollision.DamagedOther += OnDeathOrDamagedOther;
    }

    private void FixedUpdate()
    {
        if (!isShattering)
        {
            visualsTransform.localPosition = Vector3.Lerp(
                visualsTransform.localPosition,
                Vector3.zero,
                popupSpeed * Time.fixedDeltaTime);
            rb.MovePosition(transform.position + velocity * Time.fixedDeltaTime);
        }
        else
        {
            Vector3 down = -transform.up;
            rb.MovePosition(transform.position + down * 10f * Time.fixedDeltaTime);
        }
    }

    public void Initialize(Vector3 direction)
    {
        velocity = direction * speed;
        visualsTransform.localPosition = visualsTransform.up * -100f;
    }

    private void OnDeathOrDamagedOther()
    {
        isShattering = true;
    }

    private void OnDisable()
    {
        health.Died -= OnDeathOrDamagedOther;
        damageOtherOnCollision.DamagedOther -= OnDeathOrDamagedOther;
    }
}
