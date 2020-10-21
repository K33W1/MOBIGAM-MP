using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerInput : MonoBehaviour
{
    public event Action<Vector2> Fire;
    public event Action Peek;
    public event Action Cover;

    private InputMaster input = null;

    private void Awake()
    {
        input = new InputMaster();
        input.Player.Fire.performed += _ => Fire.Invoke(input.Player.Cursor.ReadValue<Vector2>());
        input.Player.Peek.performed += _ => Peek.Invoke();
        input.Player.Cover.performed += _ => Cover.Invoke();
    }

    private void OnEnable() => input.Enable();

    private void OnDisable() => input.Disable();
}
