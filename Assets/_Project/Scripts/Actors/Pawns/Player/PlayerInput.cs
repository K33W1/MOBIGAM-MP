﻿using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class PlayerInput : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSmoothing = 1.0f;
    [SerializeField] private float xMinMoveAngle = 10f;
    [SerializeField] private float yMinMoveAngle = 10f;
    [SerializeField] private float xMaxMoveAngle = 45f;
    [SerializeField] private float yMaxMoveAngle = 45f;
    [SerializeField] private float dodgeAccelerationThreshold = 1f;

    public event Action StartFire;
    public event Action StopFire;
    public event Action SwitchWeaponUp;
    public event Action SwitchWeaponDown;
    public event Action DodgeLeft;
    public event Action DodgeRight;

    public Vector2 Move { get; private set; }

    private Joystick joystick = null;
    private PlayerSwipeButton playerSwipeButton = null;

    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        joystick = UIServiceLocator.Instance.PlayerJoystick;
        playerSwipeButton = UIServiceLocator.Instance.PlayerSwipeButton;
    }

    private void OnEnable()
    {
        playerSwipeButton.SwipeLeft += () => SwitchWeaponDown?.Invoke();
        playerSwipeButton.SwipeRight += () => SwitchWeaponUp?.Invoke();
    }

    private void Update()
    {
        if (!health.IsAlive)
            return;

        FireCheck();
        SwitchWeaponCheck();
        MoveCheck();
        DodgeCheck();
    }

    public void StartFiring()
    {
        StartFire?.Invoke();
    }

    public void StopFiring()
    {
        StopFire?.Invoke();
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
        float xAngle = 0f;
        float yAngle = 0f;

        if (ControlsManager.Instance.CurrentMobileControls == MobileControls.Gyroscope)
        {
            Vector3 referenceRotation = DeviceRotation.ReferenceOrientation * Vector3.forward;
            Vector3 currentRotation = DeviceRotation.GetRotation() * Vector3.forward;

            xAngle = -Vector3.SignedAngle(referenceRotation, currentRotation, Vector3.forward);
            yAngle = -Vector3.SignedAngle(referenceRotation, currentRotation, Vector3.right);

            if (Mathf.Abs(xAngle) > xMinMoveAngle)
            {
                xAngle /= xMaxMoveAngle;
            }
            else
            {
                xAngle = 0f;
            }

            if (Mathf.Abs(yAngle) > yMinMoveAngle)
            {
                yAngle /= yMaxMoveAngle;
            }
            else
            {
                yAngle = 0f;
            }
        }

        Vector2 joystickDir = joystick.Direction;
        float rawX = Input.GetAxisRaw("Horizontal") + joystickDir.x + xAngle;
        float rawY = Input.GetAxisRaw("Vertical") + joystickDir.y + yAngle;

        Vector2 rawMove = new Vector2(rawX, rawY);
        Vector2 normalizedMove = rawMove.sqrMagnitude > 1f ? rawMove.normalized : rawMove;

        float smoothing = moveSmoothing * Time.deltaTime;
        Move = Vector2.Lerp(Move, normalizedMove, smoothing);
    }

    private void DodgeCheck()
    {
        Vector3 deviceAccel = Input.acceleration;

        if (Mathf.Abs(deviceAccel.x) < dodgeAccelerationThreshold)
            return;
        
        if (deviceAccel.x > 0)
        {
            DodgeRight?.Invoke();
        }
        else
        {
            DodgeLeft?.Invoke();
        }
    }

    private void OnDisable()
    {
        playerSwipeButton.SwipeLeft -= SwitchWeaponDown;
        playerSwipeButton.SwipeRight -= SwitchWeaponUp;
    }
}
