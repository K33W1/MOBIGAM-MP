using UnityEngine;

public class GenerateNotificationButton : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private NotificationConfig notificationConfig = null;

    public void GenerateNotification()
    {
        MobileNotificationManager.Instance.SendNotification(notificationConfig);
    }
}
