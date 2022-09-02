using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : Menu
{
    public Button Back;
    void OnEnable()
    {
        Back?.onClick.AddListener(ToBack);
    }

    void OnDisable()
    {
        Back?.onClick.RemoveListener(ToBack);
    }

    void ToBack()
    {
        MenuManager.GoTo(TypeOfMenu.Main, gameObject);
    }
}