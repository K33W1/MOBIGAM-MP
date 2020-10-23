using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    public event Action StartFire;
    public event Action StopFire;
    public event Action Peek;
    public event Action Cover;
    public event Action SwitchWeaponUp;
    public event Action SwitchWeaponDown;

    private InputMaster input = null;

    private void Awake()
    {
        input = new InputMaster();
        input.Player.StartFire.performed += _ => StartFire.Invoke();
        input.Player.StopFire.performed += _ => StopFire.Invoke();
        input.Player.Peek.performed += _ => Peek.Invoke();
        input.Player.Cover.performed += _ => Cover.Invoke();
        input.Player.SwitchUp.performed += _ => SwitchWeaponUp.Invoke();
        input.Player.SwitchDown.performed += _ => SwitchWeaponDown.Invoke();
    }

    private void OnEnable() => input.Enable();

    public Vector2 CursorPos => input.Player.Cursor.ReadValue<Vector2>();

    private void OnDisable() => input.Disable();
}
