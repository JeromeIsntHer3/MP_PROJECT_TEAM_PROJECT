using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneMenu : MonoBehaviour
{
    public GameObject phone, main, app, exit;

    public NotificationDisplay appDisplay;

    private void Awake()
    {
        phone.SetActive(false);
        app.SetActive(false);
        main.SetActive(true);
    }

    public void OnClickPhoneButton()
    {
        if (phone.activeInHierarchy)
        {
            phone.SetActive(false);
        }
        else
        {
            phone.SetActive(true);
        }
    }

    public void OnClickExit()
    {
        phone.SetActive(false);
    }

    public void OnClickApp()
    {
        OnOff(false);
        app.SetActive(true);
    }

    public void BackToMain()
    {
        OnOff(false);
        main.SetActive(true);
        exit.SetActive(true);
    }

    void OnOff(bool setting)
    {
        main.SetActive(setting);
        app.SetActive(setting);
        exit.SetActive(setting);
    }
}