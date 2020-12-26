using System;
using Unity.Notifications.Android;
using UnityEngine;

[CreateAssetMenu(fileName = "New Repeat Notification", menuName = "Mobile/Notifications/Repeat")]
public class RepeatNotificationConfig : NotificationConfig
{
    [Header("Interval")]
    [SerializeField, Min(0)] private int intervalDays = 0;
    [SerializeField, Min(0)] private int intervalHours = 0;
    [SerializeField, Min(0)] private int intervalMinutes = 10;
    [SerializeField, Min(0)] private int intervalSeconds = 0;

    public override AndroidNotification CreateAndroidNotification()
    {
        AndroidNotification notification = base.CreateAndroidNotification();
        notification.RepeatInterval = GetInterval();
        return notification;
    }

    public TimeSpan GetInterval()
    {
        return new TimeSpan(
            intervalDays,
            intervalHours,
            intervalMinutes,
            intervalSeconds);
    }
}