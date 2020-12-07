using System;
using UnityEngine;

public class SwipeEventArgs : EventArgs
{
    public Vector2 SwipePosition { get; }
    public Vector2 RawDirection { get; }
    public Direction Direction { get; }
    public GameObject HitGameObject { get; }

    public SwipeEventArgs(Vector2 swipePosition, Vector2 rawDirection, Direction direction, GameObject hitGameObject = null)
    {
        SwipePosition = swipePosition;
        RawDirection = rawDirection;
        Direction = direction;
        HitGameObject = hitGameObject;
    }
}
