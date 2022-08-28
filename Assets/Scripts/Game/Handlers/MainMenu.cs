using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, levelMenu, settings;

    private void Awake()
    {
        OnBack();
    }

    public void OnPlay()
    {
        SetAllOff();
        levelMenu.SetActive(true);
    }

    public void OnBack()
    {
        SetAllOff();
        mainMenu.SetActive(true);
    }

    public void OnSettings()
    {
        SetAllOff();
        settings.SetActive(true);
    }

    public void OnQuit()
    {
        
    }

    void SetAllOff()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        settings.SetActive(false);
    }
}