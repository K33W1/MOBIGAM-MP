using System;
using UnityEngine;
public class RotateEventArgs : EventArgs
{
    public Touch Finger1 { get; }
    public Touch Finger2 { get; }
    public float Angle { get; }
    public GameObject HitGameObject { get; }

    public RotateEventArgs(Touch finger1, Touch finger2, float angle, GameObject hitGameObject)
    {
        Finger1 = finger1;
        Finger2 = finger2;
        Angle = angle;
        HitGameObject = hitGameObject;
    }
}
