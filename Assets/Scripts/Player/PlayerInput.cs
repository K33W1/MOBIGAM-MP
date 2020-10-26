using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSmoothing = 1.0f;

    public event Action StartFire;
    public event Action StopFire;
    public event Action SwitchWeaponUp;
    public event Action SwitchWeaponDown;

    private InputMaster input = null;

    public Vector2 Move { get; private set; }

    private void Awake()
    {
        input = new InputMaster();
        input.Player.StartFire.performed += _ => StartFire?.Invoke();
        input.Player.StopFire.performed += _ => StopFire?.Invoke();
        input.Player.SwitchUp.performed += _ => SwitchWeaponUp?.Invoke();
        input.Player.SwitchDown.performed += _ => SwitchWeaponDown?.Invoke();
    }

    private void OnEnable() => input.Enable();

    private void Update()
    {
        Vector2 keyboardMove = input.Player.KeyboardMove.ReadValue<Vector2>();
        Vector2 joystickMove = input.Player.JoystickMove.ReadValue<Vector2>();

        Vector2 rawMove = keyboardMove + joystickMove;
        Vector2 normalizedMove = rawMove.sqrMagnitude > 1f ? rawMove.normalized : rawMove;

        float smoothing = moveSmoothing * Time.deltaTime;
        Move = Vector2.Lerp(Move, normalizedMove, smoothing);
    }

    private void OnDisable() => input.Disable();
}
