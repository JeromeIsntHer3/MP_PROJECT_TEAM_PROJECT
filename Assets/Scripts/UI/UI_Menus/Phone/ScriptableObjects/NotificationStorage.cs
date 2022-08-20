using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (fileName = "NotificationStorage",menuName = "Notification/Notification Storage")]
public class NotificationStorage : ScriptableObject
{
    public string storageName;
    public List<NotificationData> notificationList;
    public NotficationType storageType;
}