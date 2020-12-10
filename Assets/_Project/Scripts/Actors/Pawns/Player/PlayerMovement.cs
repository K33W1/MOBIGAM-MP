using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Camera playerCamera = null;
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private Transform playerVisual = null;

    [Header("Settings")]
    [SerializeField] private PlayerConfig _playerConfig = null;
    [SerializeField, Range(0, 90)] private float leanLimit = 75f;
    [SerializeField, Min(0)] private float leanSmoothing = 3f;
    [SerializeField, Min(0)] private float lookSpeed = 100f;
    [SerializeField] private AnimationCurve dodgeSpeedCurve = null;
    [SerializeField, Min(0)] private float dodgeDuration = 1f;
    [SerializeField, Min(0)] private float dodgeSpeedMult = 2f;

    private Health health = null;
    private PlayerInput input = null;

    private bool canControl = true;
    private bool isDodging = false;
    private float dodgeDirection = 0f;
    private float dodgeTimer = 0f;

    private void Awake()
    {
        health = GetComponent<Health>();
        input = GetComponent<PlayerInput>();

        health.Died += OnDeath;
        input.DodgeLeft += () => StartDodge(-1f);
        input.DodgeRight += () => StartDodge(1f);
    }

    private void Start()
    {
        canControl = true;
    }

    private void Update()
    {
        if (canControl)
        {
            Vector2 rawMove = Vector2.zero;

            if (isDodging)
            {
                dodgeTimer += Time.deltaTime;
                
                float dodgePercent = dodgeTimer / dodgeDuration;
                float xMove = dodgeSpeedCurve.Evaluate(dodgePercent) * dodgeDirection;

                rawMove = new Vector2(xMove, 0f) * dodgeSpeedMult;
                
                if (dodgeTimer >= dodgeDuration)
                {
                    isDodging = false;
                }
            }
            else
            {
                rawMove = input.Move;
            }

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
        Vector3 pos = playerCamera.WorldToViewportPoint(playerTransform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        playerTransform.position = playerCamera.ViewportToWorldPoint(pos);
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
        float smoothing = leanSmoothing * Time.deltaTime;
        Vector3 currentAngle = playerVisual.localEulerAngles;
        Vector3 targetAngle = new Vector3
        (
            currentAngle.x,
            currentAngle.y,
            Mathf.LerpAngle(currentAngle.z, -moveX * leanLimit, smoothing)
        );
        playerVisual.localEulerAngles = targetAngle;
    }

    private void StartDodge(float direction)
    {
        isDodging = true;
        dodgeTimer = 0f;
        dodgeDirection = direction;
    }

    private void OnDeath()
    {
        canControl = false;
    }
}
