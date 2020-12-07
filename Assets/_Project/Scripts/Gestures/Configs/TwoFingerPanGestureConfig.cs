using System;
using UnityEngine;

[Serializable]
public class TwoFingerPanGestureConfig
{
    [SerializeField] private float maxDistance = 0.5f;

    public float MaxDistance => maxDistance;

    public bool IsValidGesture(Touch finger1, Touch finger2)
    {

        return finger1.phase == TouchPhase.Moved &&
               finger2.phase == TouchPhase.Moved &&
               Vector2.Distance(finger1.position, finger2.position) <= MaxDistance * Screen.dpi;
    }
}
