using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Alerts : MonoBehaviour
{
    [Header("Alert Attributes")]
    [SerializeField]
    private float animDurr;
    [SerializeField]
    private float alertDurr;
    [SerializeField]
    private TextMeshProUGUI alertText;

    private RectTransform uiTransform;

    [SerializeField]

    void Start() 
    {
        uiTransform = GetComponent<RectTransform>();
        uiTransform.anchoredPosition = new Vector2(0,-95);
    }

    public void Run(string text)
    {
        StartCoroutine(Alert(text));
    }

    IEnumerator Alert(string text)
    {
        AlertStart(text);
        yield return new WaitForSeconds(alertDurr);
        AlertEnd();
    }

    void AlertStart(string text)
    {
        alertText.text = text;
        LeanTween.move(uiTransform, new Vector3(0, 75, 0), animDurr).setEaseInSine();
    }

    void AlertEnd()
    {
        LeanTween.move(uiTransform, new Vector3(0, -95, 0), animDurr).setEaseInSine();
    }
}