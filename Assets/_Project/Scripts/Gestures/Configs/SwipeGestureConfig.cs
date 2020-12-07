using System;
using UnityEngine;

[Serializable]
public class SwipeGestureConfig 
{
    [SerializeField] private float minSwipeDistance = 0.2f;
    [SerializeField] private float maxSwipeDuration = 2f;

    public float MinSwipeDistance => minSwipeDistance;
    public float MaxSwipeDuration => maxSwipeDuration;

    public bool IsValidGesture(float gestureTime, Vector2 startPos, Vector2 endPos)
    {
        return gestureTime <= MaxSwipeDuration &&
               Vector2.Distance(startPos, endPos) >= MinSwipeDistance * Screen.dpi;
    }
}
