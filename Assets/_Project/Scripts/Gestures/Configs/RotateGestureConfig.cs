using System;
using UnityEngine;

[Serializable]
public class RotateGestureConfig
{
    [SerializeField] private float minDistance = 0.7f;
    [SerializeField] private float minDelta = 1f;

    public float MinDistance => minDistance;
    public float MinDelta => minDelta;

    public bool IsValidGesture(Touch finger1, Touch finger2)
    {
        return (finger1.phase == TouchPhase.Moved || finger2.phase == TouchPhase.Moved) && 
               Vector2.Distance(finger1.position, finger2.position) >= minDistance * Screen.dpi;
    }
}
