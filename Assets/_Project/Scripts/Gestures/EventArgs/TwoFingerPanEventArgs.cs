using System;
using UnityEngine;

public class TwoFingerPanEventArgs : EventArgs
{
    public Touch Finger1 { get; }
    public Touch Finger2 { get; }

    public TwoFingerPanEventArgs(Touch finger1, Touch finger2)
    {
        Finger1 = finger1;
        Finger2 = finger2;
    }


}
