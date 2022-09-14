using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : Menu
{
    public Button Play, Settings, Quit;
    private CanvasGroup thisTransform;

    void Awake()
    {
        thisTransform = GetComponentInParent<CanvasGroup>();
        StartCoroutine(GameStart());
        MenuManager.Initialise();
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(4);
        LeanTween.alphaCanvas(thisTransform, 1, 1);
    }

    void OnEnable()
    {
        Play?.onClick.AddListener(ToPlay);
        Settings?.onClick.AddListener(ToSettings);
        Quit?.onClick.AddListener(ToQuit);
    }

    void OnDisable()
    {
        Play?.onClick.RemoveListener(ToPlay);
        Settings?.onClick.RemoveListener(ToSettings);
        Quit?.onClick.RemoveListener(ToQuit);
    }

    void ToPlay()
    {
        MenuManager.GoTo(TypeOfMenu.Level, gameObject);
    }

    void ToSettings()
    {
        MenuManager.GoTo(TypeOfMenu.Settings,gameObject);
    }

    void ToQuit()
    {
        Application.Quit();
    }
}