using UnityEngine;
using System.Collections;
using System;

public class MainMenuHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu, levelMenu, settingsMenu;

    void Awake()
    {
        TurnOffAll();
        mainMenu.SetActive(true);
    }

    public void Play()
    {
        TurnOffAll();
        AnimateUI(levelMenu, true, 0.3f);
    }

    public void Settings()
    {
        TurnOffAll();
        AnimateUI(settingsMenu, true, 0.3f);
    }

    public void BackToMainMenu()
    {
        TurnOffAll();
        AnimateUI(mainMenu, true, 0.3f);
    }

    void TurnOffAll()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    #region Animation Function
    void AnimateUI(GameObject go, bool active, float duration, Action func = null)
    {
        if (active)
        {
            StartCoroutine(WaitForAnimBefore(duration, go, func));
        }
        else
        {
            StartCoroutine(WaitForAnimAfter(duration, go, func));
        }
    }
    #endregion


    #region Coroutines
    IEnumerator WaitForAnimBefore(float time, GameObject go, Action func)
    {
        go.SetActive(true);
        go.transform.localScale = Vector2.zero;
        go.transform.LeanScale(Vector2.one, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        if (func != null) func();
    }
    IEnumerator WaitForAnimAfter(float time, GameObject go, Action func)
    {
        go.transform.LeanScale(Vector2.zero, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);
        if (func != null) func();
    }
    #endregion
}
