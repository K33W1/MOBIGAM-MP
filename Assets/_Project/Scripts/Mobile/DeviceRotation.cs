using UnityEngine;

public static class DeviceRotation
{
    public static Quaternion ReferenceOrientation { get; private set; }
    public static bool HasGyroscope => SystemInfo.supportsGyroscope;

    private static bool isGyroscopeInitialized = false;

    [RuntimeInitializeOnLoadMethod]
    private static void Awake()
    {
        ReferenceOrientation = Quaternion.identity;
        isGyroscopeInitialized = false;
    }

    public static void ResetReferenceRotation()
    {
        ReferenceOrientation = ReadGyroscopeRotation();
    }

    public static Quaternion GetRotation()
    {
        if (!isGyroscopeInitialized)
        {
            InitializeGyroscope();
        }

        return HasGyroscope ? ReadGyroscopeRotation() : Quaternion.identity;
    }

    private static void InitializeGyroscope()
    {
        if (!SystemInfo.supportsGyroscope)
            return;

        Input.gyro.enabled = true;
        isGyroscopeInitialized = true;
        ReferenceOrientation = ReadGyroscopeRotation();
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f)
               * Input.gyro.attitude
               * new Quaternion(0f, 0f, 1f, 0f);
    }
}
