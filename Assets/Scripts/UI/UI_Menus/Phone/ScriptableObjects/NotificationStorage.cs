using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu (fileName = "AppDisplay",menuName = "AppDisplay/Notification Storage")]
public class NotificationStorage : ScriptableObject
{
    public string storageName;
    public List<NotificationData> notificationList;
}