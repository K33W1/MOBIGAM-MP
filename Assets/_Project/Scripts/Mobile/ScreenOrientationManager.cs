using System;
using Kiwi.Common;
using UnityEngine;

public enum GeneralOrientation
{
    Landscape,
    Portrait
}

public class ScreenOrientationManager : MonoBehaviourSingleton<ScreenOrientationManager>
{
    public event Action<ScreenOrientation> DeviceOrientationChanged;
    public event Action<GeneralOrientation> GeneralOrientationChanged;

    public GeneralOrientation CurrentGeneralOrientation { get; private set; }

    private ScreenOrientation currOrientation = ScreenOrientation.LandscapeLeft;
    private ScreenOrientation prevOrientation = ScreenOrientation.LandscapeLeft;

    protected override void SingletonAwake()
    {
        
    }

    private void Update()
    {
        UpdateCurrentOrientation();

        if (prevOrientation != currOrientation)
        {
            if (currOrientation == ScreenOrientation.LandscapeLeft ||
                currOrientation == ScreenOrientation.LandscapeRight)
            {
                CurrentGeneralOrientation = GeneralOrientation.Landscape;
                GeneralOrientationChanged?.Invoke(CurrentGeneralOrientation);
            }
            else if (currOrientation == ScreenOrientation.Portrait ||
                     currOrientation == ScreenOrientation.PortraitUpsideDown)
            {
                CurrentGeneralOrientation = GeneralOrientation.Portrait;
                GeneralOrientationChanged?.Invoke(CurrentGeneralOrientation);
            }

            DeviceOrientationChanged?.Invoke(currOrientation);
        }

        prevOrientation = currOrientation;
    }

    private void UpdateCurrentOrientation()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            currOrientation = Screen.orientation;
        }
        else if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            if (Screen.width > Screen.height)
            {
                currOrientation = ScreenOrientation.LandscapeLeft;
            }
            else
            {
                currOrientation = ScreenOrientation.Portrait;
            }
        }
    }


    protected override void SingletonOnDestroy()
    {
        
    }
}
