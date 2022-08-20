using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NotificationSlot : MonoBehaviour
{
    public NotificationData notification;
    public TextMeshProUGUI thisHeader;
    public TextMeshProUGUI thisInfo;
    public Image thisImage;
    public Image highlight;

    public void SetNotificationSlot(NotificationData data)
    {
        notification = data;
        if (notification)
        {
            thisImage.color = notification.backgroundColor;
            thisHeader.text = notification.notificationHeader;
            thisInfo.text = notification.notificationText;
            if(notification.seen == true)
            {
                highlight.color = new Vector4(1, 1, 1, 0);
            }
        }
    }

    public void OnClicked()
    {
        if (notification)
        {
            highlight.color = new Vector4(1, 1, 1, 0);
            notification.seen = true;
        }
    }
}
