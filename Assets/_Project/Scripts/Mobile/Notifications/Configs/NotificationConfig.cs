using System;
using Unity.Notifications.Android;
using UnityEngine;

public abstract class NotificationConfig : ScriptableObject
{
    [Header("Base Settings")]
    [SerializeField] private string title = "Sample title";
    [SerializeField] private string text = "Sample text";
    [SerializeField] private string smallIcon = "small_icon_0";
    [SerializeField] private string largeIcon = "large_icon_0";

    [Header("Delay")]
    [SerializeField, Min(0)] private int delayDays = 0;
    [SerializeField, Min(0)] private int delayHours = 0;
    [SerializeField, Min(0)] private int delayMinutes = 0;
    [SerializeField, Min(0)] private int delaySeconds = 5;

    public virtual AndroidNotification CreateAndroidNotification()
    {
        return new AndroidNotification
        {
            Title = title,
            Text = text,
            SmallIcon = smallIcon,
            LargeIcon = largeIcon,
            FireTime = DateTime.Now.Add(new TimeSpan(
                delayDays,
                delayHours,
                delayMinutes,
                delaySeconds))
        };
    }
}
