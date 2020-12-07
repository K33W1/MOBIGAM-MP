using System;
using UnityEngine;

[Serializable]
public class PinchSpreadGestureConfig
{
    [SerializeField] private float minChange = 0.1f;

    public float MinChange => minChange;

    public bool IsValidGesture(Touch finger1, Touch finger2)
    {
        return finger1.phase == TouchPhase.Moved ||
               finger2.phase == TouchPhase.Moved;
    }
}
