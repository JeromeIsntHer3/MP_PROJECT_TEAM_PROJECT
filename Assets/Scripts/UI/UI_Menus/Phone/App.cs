using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class App : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI notifText;
    private int noOfNotifs;
    [SerializeField]
    private GameObject alert;
    [SerializeField]
    private NotificationStorage thisStorage;

    void Awake()
    {
        alert.SetActive(false);
    }

    void OnEnable()
    {
        foreach(NotificationData data in thisStorage.notificationList)
        {
            if(data.seen == false)
            {
                noOfNotifs++;
            }
        }
        if(noOfNotifs > 0)
        {
            alert.SetActive(true);
            notifText.text = noOfNotifs.ToString();
        }
        else
        {
            alert.SetActive(false);
        }
    }

    void OnDisable()
    {
        noOfNotifs = 0;
    }
}