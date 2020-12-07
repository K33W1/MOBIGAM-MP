using System;
using UnityEngine;

[Serializable]
public class TapGestureConfig
{
    [SerializeField] private float minTapDuration = 0.7f;
    [SerializeField] private float maxTapDistance = 0.1f;

    public float MinTapDuration => minTapDuration;
    public float MaxTapDistance => maxTapDistance;

    public bool IsValidGesture(float gestureTime, Vector2 startPos, Vector2 endPos)
    {
        return gestureTime <= MinTapDuration &&
               Vector2.Distance(startPos, endPos) <= MaxTapDistance * Screen.dpi;
    }
}
