using System;
using System.Collections;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public static UIAnimation uiAnim;

    void Awake()
    {
        uiAnim = this;
    }

    public void AnimateUI(GameObject go, bool active, float duration, Action func = null)
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

    IEnumerator WaitForAnimBefore(float time, GameObject go, Action func)
    {
        go.SetActive(true);
        go.transform.localScale = Vector2.zero;

        LeanTween.scale(go,Vector2.one,time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        if (func != null) func();
    }
    IEnumerator WaitForAnimAfter(float time, GameObject go, Action func)
    {
        LeanTween.scale(go, Vector2.one, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);
        if (func != null) func();
    }
}
