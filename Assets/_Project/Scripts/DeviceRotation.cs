using UnityEngine;

public static class DeviceRotation
{
    public static bool HasGyroscope => SystemInfo.supportsGyroscope;
    public static Vector3 ReferenceAcceleration = Vector3.forward;

    private static bool isGyroscopeInitialized = false;
    private static bool isAccelerometerInitialized = false;

    public static Vector3 GetAcceleration()
    {
        if (!isAccelerometerInitialized)
        {
            InitializeAccelerometer();
        }

        return HasGyroscope ? Input.acceleration : Vector3.forward;
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
    }

    private static void InitializeAccelerometer()
    {
        if (!isGyroscopeInitialized)
        {
            InitializeGyroscope();
            if (!isGyroscopeInitialized)
                return;
        }

        if (Input.acceleration == Vector3.zero)
            return;

        ReferenceAcceleration = Input.acceleration;
        isAccelerometerInitialized = true;
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        return new Quaternion(0.5f, 0.5f, -0.5f, 0.5f)
               * Input.gyro.attitude
               * new Quaternion(0f, 0f, 1f, 0f);
    }
}
