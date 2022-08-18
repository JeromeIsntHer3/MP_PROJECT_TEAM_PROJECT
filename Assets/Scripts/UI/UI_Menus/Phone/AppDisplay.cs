using UnityEngine;
using TMPro;

public class AppDisplay : MonoBehaviour
{
    [SerializeField]
    private NotificationStorage notificationStorage1;
    [SerializeField]
    private NotificationStorage notificationStorage2;
    [SerializeField]
    private NotificationStorage notificationStorage3;
    [SerializeField]
    private NotificationStorage notificationStorage4;

    [SerializeField]
    private GameObject display;
    [SerializeField]
    private GameObject notificationPrefab;
    [SerializeField]
    private TextMeshProUGUI appTitle;

    [SerializeField]
    private Alerts alerts;

    public enum AppType
    {
        App1,App2,App3,App4
    }

    [HideInInspector]
    public AppType appType;

    

    public void AddNotification(int storage,NotificationData data)
    {
        switch (storage)
        {
            case 1:
                notificationStorage1.notificationList.Add(data);
                alerts.Run("New Network Alert!");
                break;
            case 2:
                notificationStorage1.notificationList.Add(data);
                break;
            case 3:
                notificationStorage1.notificationList.Add(data);
                break;
            case 4:
                notificationStorage1.notificationList.Add(data);
                break;
            default:
                return;
        }
    }

    public void SetUpSlots()
    {
        if (display)
        {
            foreach(NotificationData notification in CurrentStorage().notificationList)
            {
                GameObject temp = Instantiate(notificationPrefab, display.transform.position, Quaternion.identity, display.transform);
                temp.transform.SetParent(display.transform);
                NotificationSlot newSlot = temp.GetComponent<NotificationSlot>();
                if (newSlot)
                {
                    newSlot.SetNotificationSlot(notification);
                }
            }
            appTitle.text = CurrentStorage().storageName;
        }
    }

    public void ClearSlots()
    {
        if (display)
        {
            for(int i = 0; i < display.transform.childCount; i++)
            {
                Destroy(display.transform.GetChild(i).gameObject);
            }
        }
    }

    NotificationStorage CurrentStorage()
    {
        NotificationStorage currStorage;
        switch (appType)
        {
            case AppType.App1:
                currStorage = notificationStorage1;
                break;
            case AppType.App2:
                currStorage = notificationStorage2;
                break;
            case AppType.App3:
                currStorage = notificationStorage3;
                break;
            case AppType.App4:
                currStorage = notificationStorage4;
                break;
            default:
                currStorage = null;
                break;
        }
        return currStorage;
    }
}