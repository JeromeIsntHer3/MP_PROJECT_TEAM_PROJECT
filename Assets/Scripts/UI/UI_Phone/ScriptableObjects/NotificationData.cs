using UnityEngine;

[CreateAssetMenu(fileName = "NotificationData", menuName = "Notification/NotficationData")]
public class NotificationData : ScriptableObject
{
    public string notificationHeader;
    [Multiline]
    public string notificationText;
    public Color backgroundColor;
    public NotficationType notficationType;
    public bool seen = false;
}

public enum NotficationType
{
    Network, Message, Medical, Info
}