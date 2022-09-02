using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonAnim : MonoBehaviour
{
    [Header("UI Object")]
    public Vector3 hoverSize;
    public Vector3 hoverRotation;
    public float animSpeed;
    private RectTransform buttonTransform;
    private Button thisButton;

    [Header("UI Text")]
    public TextMeshProUGUI text;
    public Vector3 textHoverRotation;

    void Awake()
    {
        thisButton = GetComponent<Button>();
        buttonTransform = GetComponent<RectTransform>();
    }

    public void Grow()
    {
        if (thisButton.interactable == false) return;
        LeanTween.scale(buttonTransform.gameObject, hoverSize, animSpeed);
        LeanTween.rotate(buttonTransform.gameObject, hoverRotation, animSpeed);
        if (!text) return;
        LeanTween.rotate(text.gameObject, textHoverRotation, animSpeed);
    }

    public void Shrink()
    {
        if (thisButton.interactable == false) return;
        LeanTween.scale(buttonTransform.gameObject, Vector3.one, animSpeed);
        LeanTween.rotate(buttonTransform.gameObject, Vector3.zero, animSpeed);
        if (!text) return;
        LeanTween.rotate(text.gameObject, Vector3.zero, animSpeed);
    }
}