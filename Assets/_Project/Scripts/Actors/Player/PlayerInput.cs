using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class PlayerInput : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSmoothing = 1.0f;

    public event Action StartFire;
    public event Action StopFire;
    public event Action SwitchWeaponUp;
    public event Action SwitchWeaponDown;

    public Vector2 Move { get; private set; }

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (!health.IsAlive)
            return;

        FireCheck();
        SwitchWeaponCheck();
        MoveCheck();
    }

    private void FireCheck()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartFire?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            StopFire?.Invoke();
        }
    }

    private void SwitchWeaponCheck()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchWeaponDown?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            SwitchWeaponUp?.Invoke();
        }
    }

    private void MoveCheck()
    {
        float rawX = Input.GetAxisRaw("Horizontal");
        float rawY = Input.GetAxisRaw("Vertical");

        Vector2 rawMove = new Vector2(rawX, rawY);
        Vector2 normalizedMove = rawMove.sqrMagnitude > 1f ? rawMove.normalized : rawMove;

        float smoothing = moveSmoothing * Time.deltaTime;
        Move = Vector2.Lerp(Move, normalizedMove, smoothing);
    }
}
