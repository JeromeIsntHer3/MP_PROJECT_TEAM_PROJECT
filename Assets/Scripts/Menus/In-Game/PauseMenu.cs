using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : Menu
{
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;

    void OnEnable()
    {
        settingsButton?.onClick.AddListener(ToSettings);
        quitButton?.onClick.AddListener(ToQuit);
    }

    void OnDisable()
    {
        settingsButton?.onClick.RemoveListener(ToSettings);
        quitButton?.onClick.RemoveListener(ToQuit);
    }

    public void ToSettings()
    {
        MenuManager.GoTo(TypeOfMenu.Settings, gameObject);
    }
    void ToQuit()
    {
        GameEvents.current.LoadLevel(0);
    }
}