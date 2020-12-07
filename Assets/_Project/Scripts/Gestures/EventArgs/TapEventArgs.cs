using System;
using UnityEngine;

public class TapEventArgs : EventArgs
{
    public Vector2 TapPosition { get; }
    public GameObject TappedObject { get; }

    public TapEventArgs(Vector2 pos, GameObject obj = null)
    {
        TapPosition = pos;
        TappedObject = obj;
    }
}
