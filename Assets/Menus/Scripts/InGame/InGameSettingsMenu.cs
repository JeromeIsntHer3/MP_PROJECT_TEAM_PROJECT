using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameSettingsMenu : Menu
{
    public Button backButton;

    void OnEnable()
    {
        backButton?.onClick.AddListener(ToPauseMenu);
    }

    void OnDisable()
    {
        backButton?.onClick.RemoveListener(ToPauseMenu);
    }

    void ToPauseMenu()
    {
        MenuManager.GoTo(TypeOfMenu.Pause, gameObject);
    }
}