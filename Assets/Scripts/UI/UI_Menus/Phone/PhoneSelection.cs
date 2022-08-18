using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSelection : MonoBehaviour
{
    public GameObject phone, main, appButton1, appButton2, appButton3, appButton4, app, exit;

    public AppDisplay appDisplay;

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

    public void OnClickApp1()
    {
        OnOff(false);
        app.SetActive(true);
        appDisplay.appType = AppDisplay.AppType.App1;
        appDisplay.ClearSlots();
        appDisplay.SetUpSlots();
    }
    public void OnClickApp2()
    {
        OnOff(false);
        app.SetActive(true);
        appDisplay.appType = AppDisplay.AppType.App2;
        appDisplay.ClearSlots();
        appDisplay.SetUpSlots();
    }
    public void OnClickApp3()
    {
        OnOff(false);
        app.SetActive(true);
        appDisplay.appType = AppDisplay.AppType.App3;
        appDisplay.ClearSlots();
        appDisplay.SetUpSlots();
    }
    public void OnClickApp4()
    {
        OnOff(false);
        app.SetActive(true);
        appDisplay.appType = AppDisplay.AppType.App4;
        appDisplay.ClearSlots();
        appDisplay.SetUpSlots();
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