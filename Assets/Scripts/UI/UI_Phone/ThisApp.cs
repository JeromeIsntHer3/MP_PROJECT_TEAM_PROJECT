using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ThisApp : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI notifText;
    [SerializeField]
    private GameObject alertNotif;
    [SerializeField]
    private NotificationStorage thisStorage;
    [SerializeField]
    private NotificationDisplay display;
    [SerializeField]
    private Alerts alerts;
    public NotficationType type;

    private int noOfNotifs;
    private Button appButton;

    void Awake()
    {
        alertNotif.SetActive(false);
        appButton = GetComponent<Button>();
        appButton.onClick.AddListener(ChangeStorage);
    }

    void ChangeStorage()
    {
        display.ClearSlots();
        display.Storage = thisStorage;
        display.SetUpSlots();
    }

    void OnEnable()
    {
        SetupAlerts();
    }

    private void OnDisable()
    {
    }

    public void SetupAlerts()
    {
        noOfNotifs = 0;
        foreach (NotificationData data in thisStorage.notificationList)
        {
            if (data.seen == false)
            {
                noOfNotifs++;
            }
        }
        if (noOfNotifs > 0)
        {
            alertNotif.SetActive(true);
            notifText.text = noOfNotifs.ToString();
        }
        else
        {
            alertNotif.SetActive(false);
        }
    }

    //Runs at TriggerZone TypeOf: Notification
    public void AddNotification(NotificationData data)
    {
        if (thisStorage.notificationList.Contains(data)) return;

        thisStorage.notificationList.Add(data);
        SetupAlerts();
        alerts.Run(type.ToString());
    }
}