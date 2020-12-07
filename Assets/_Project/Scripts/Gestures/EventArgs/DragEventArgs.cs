using System;
using UnityEngine;

public class DragEventArgs : EventArgs
{
    public Touch TargetFinger { get; }
    public GameObject HitGameObject { get; }

    public DragEventArgs(Touch targetFinger, GameObject hitGameObject = null)
    {
        TargetFinger = targetFinger;
        HitGameObject = hitGameObject;
    }
}
