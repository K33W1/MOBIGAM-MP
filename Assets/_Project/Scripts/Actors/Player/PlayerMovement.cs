using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private new Camera camera = null;
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private Transform playerVisual = null;

    [Header("Settings")]
    [SerializeField] private PlayerConfig _playerConfig = null;
    [SerializeField, Range(0, 90)] private float leanLimit = 75f;
    [SerializeField, Min(0)] private float leanSmoothing = 0.1f;
    [SerializeField, Min(0)] private float lookSpeed = 100f;

    private Health health = null;
    private PlayerInput input = null;

    private bool canControl = true;

    private void Awake()
    {
        health = GetComponent<Health>();
        input = GetComponent<PlayerInput>();

        health.Died += OnDeath;
    }

    private void Start()
    {
        canControl = true;
    }

    private void Update()
    {
        if (canControl)
        {
            Vector2 rawMove = input.Move;
            Vector3 move = new Vector3
            (
                rawMove.x * _playerConfig.MoveSpeed * Time.deltaTime,
                rawMove.y * _playerConfig.MoveSpeed * Time.deltaTime
            );

            playerTransform.localPosition += move;
            ClampPosition();
            AimRotation(rawMove);
            HorizontalLean(rawMove.x);
        }
    }

    private void ClampPosition()
    {
        Vector3 pos = camera.WorldToViewportPoint(playerTransform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        playerTransform.position = camera.ViewportToWorldPoint(pos);
    }

    private void AimRotation(Vector2 move)
    {
        Vector3 aimTarget = new Vector3(move.x, move.y, 1);
        float smoothing = Mathf.Deg2Rad * lookSpeed * Time.deltaTime;
        Quaternion targetRotation = Quaternion.LookRotation(aimTarget);
        Quaternion smoothRotation = Quaternion.Lerp(playerTransform.rotation, targetRotation, smoothing);

        playerTransform.rotation = smoothRotation;
    }

    void HorizontalLean(float moveX)
    {
        Vector3 currentAngle = playerVisual.localEulerAngles;
        Vector3 targetAngle = new Vector3
        (
            currentAngle.x,
            currentAngle.y,
            Mathf.LerpAngle(currentAngle.z, -moveX * leanLimit, leanSmoothing)
        );
        playerVisual.localEulerAngles = targetAngle;
    }

    private void OnDeath()
    {
        canControl = false;
    }
}
