using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationIntervalDropdown : MonoBehaviour
{
    private TMP_Dropdown dropdown = null;

    private void Awake()
    {
        dropdown = GetComponent<TMP_Dropdown>();
        dropdown.onValueChanged.AddListener(OnDropdownChanged);
    }

    private void Start()
    {
        var notificationManager = MobileNotificationManager.Instance;
        var repeatNotifications =
            notificationManager.AllRepeatNotifications;

        List<string> intervals = new List<string>(repeatNotifications.Count);
        foreach (RepeatNotificationConfig notif in repeatNotifications)
        {
            intervals.Add(GetNotificationInterval(notif));
        }

        dropdown.ClearOptions();
        dropdown.AddOptions(intervals);
        dropdown.SetValueWithoutNotify(notificationManager.ActiveRepeatNotificationsIndexes[0]);
    }

    private string GetNotificationInterval(RepeatNotificationConfig notificationConfig)
    {
        TimeSpan interval = notificationConfig.GetInterval();

        string length = string.Empty;
        if (interval.Days > 0) length += $"{interval.Days} Days";
        if (interval.Hours > 0) length += $"{interval.Hours} Hours";
        if (interval.Minutes > 0) length += $"{interval.Minutes} Minutes";
        if (interval.Seconds > 0) length += $"{interval.Seconds} Seconds";

        return length;
    }

    private void OnDropdownChanged(int index)
    {
        var mobileNotificationManager = MobileNotificationManager.Instance;
        mobileNotificationManager.ChangeFirstRepeatNotification(index);
    }
}
