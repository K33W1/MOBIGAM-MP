using Unity.Notifications.Android;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data Notification", menuName = "Mobile/Notifications/Data")]
public class DataNotificationConfig : NotificationConfig
{
    [Header("Advanced Settings")]
    [SerializeField, TextArea(1, 3)] private string data = string.Empty;

    public override AndroidNotification CreateAndroidNotification()
    {
        AndroidNotification notification = base.CreateAndroidNotification();
        notification.IntentData = data;
        return notification;
    }
}
