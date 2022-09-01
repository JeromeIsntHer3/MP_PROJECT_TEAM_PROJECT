using UnityEngine;
using TMPro;

public class NotificationDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject display;
    [SerializeField]
    private GameObject notificationPrefab;
    [SerializeField]
    private TextMeshProUGUI appTitle;

    public NotificationStorage Storage;

    void OnEnable()
    { 
    }

    void OnDisable()
    {
    }


    //Runs at ThisApp.cs
    public void SetUpSlots()
    {
        appTitle.text = Storage.storageName;
        if (display)
        {
            foreach (NotificationData data in Storage.notificationList)
            {
                GameObject temp = Instantiate(notificationPrefab, display.transform.position, Quaternion.identity, display.transform);
                temp.transform.SetParent(display.transform);
                NotificationSlot newSlot = temp.GetComponent<NotificationSlot>();
                if (newSlot)
                {
                    newSlot.SetNotificationSlot(data);
                }
            }
        }
    }

    //Runs at ThisApp.cs
    public void ClearSlots()
    {
        if (display)
        {
            if (display.transform.childCount == 0) return;
            for(int i = 0; i < display.transform.childCount; i++)
            {
                Destroy(display.transform.GetChild(i).gameObject);
            }
        }
    }
}