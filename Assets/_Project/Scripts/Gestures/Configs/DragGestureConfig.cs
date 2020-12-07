using System;
using UnityEngine;

[Serializable]
public class DragGestureConfig
{
    [SerializeField] private float minDuration = 0.5f;

    public float MinDuration => minDuration;

    public bool IsValidGesture(float gestureTime)
    {
        return gestureTime >= MinDuration;
    }
}
