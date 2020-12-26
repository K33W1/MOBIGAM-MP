using System.Collections.Generic;
using Kiwi.Common;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotificationManager : MonoBehaviourSingleton<MobileNotificationManager>
{
    [SerializeField] private List<RepeatNotificationConfig> allRepeatNotifications = new List<RepeatNotificationConfig>();
    [SerializeField] private List<int> startingRepeatNotifications = new List<int>();

    public List<RepeatNotificationConfig> AllRepeatNotifications => allRepeatNotifications;
    public List<int> ActiveRepeatNotificationsIDs { get; } = new List<int>();
    public List<int> ActiveRepeatNotificationsIndexes { get; } = new List<int>();

    private AndroidNotificationChannel defaultNotificationChannel;

    protected override void SingletonAwake()
    {
        InitializeNotificationChannels();
        InitializeStartingRepeatNotifications();
    }

    private void InitializeNotificationChannels()
    {
        defaultNotificationChannel = new AndroidNotificationChannel
        {
            Id = "default_channel",
            Name = " Default Channel",
            Description = "For generic notifications.",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(defaultNotificationChannel);
    }

    private void InitializeStartingRepeatNotifications()
    {
        foreach (int index in startingRepeatNotifications)
        {
            RepeatNotificationConfig notification =AllRepeatNotifications[index];
            int id = SendNotification(notification);
            ActiveRepeatNotificationsIDs.Add(id);
            ActiveRepeatNotificationsIndexes.Add(index);
        }
    }

    public int SendNotification(NotificationConfig notificationConfig)
    {
        AndroidNotification notification =
            notificationConfig.CreateAndroidNotification();
        return AndroidNotificationCenter
            .SendNotification(notification, "default_channel");
    }

    public int ChangeRepeatNotification(int newNotifIndex, int activeNotifToCancel)
    {
        RepeatNotificationConfig newNotifConfig = AllRepeatNotifications[newNotifIndex];
        int oldNotifId = ActiveRepeatNotificationsIDs[activeNotifToCancel];
        int newNotifId = SendNotification(newNotifConfig);

        AndroidNotificationCenter.CancelNotification(oldNotifId);
        ActiveRepeatNotificationsIDs[activeNotifToCancel] = newNotifId;
        ActiveRepeatNotificationsIndexes[activeNotifToCancel] = newNotifIndex;

        return newNotifId;
    }

    public int ChangeFirstRepeatNotification(int newNotifIndex)
    {
        return ChangeRepeatNotification(newNotifIndex, 0);
    }

    protected override void SingletonOnDestroy()
    {
        
    }
}
