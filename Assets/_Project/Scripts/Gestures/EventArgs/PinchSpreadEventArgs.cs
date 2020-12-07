using System;
using UnityEngine;

public class PinchSpreadEventArgs : EventArgs
{
    public Touch Finger1 { get; }
    public Touch Finger2 { get; }
    public float Delta { get; }
    public GameObject HitGameObject { get; }

    public PinchSpreadEventArgs(Touch finger1, Touch finger2, float delta, GameObject hitGameObject)
    {
        Finger1 = finger1;
        Finger2 = finger2;
        Delta = delta;
        HitGameObject = hitGameObject;
    }
}
