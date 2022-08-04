using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonAnim : MonoBehaviour
{
    [Header("UI Object")]
    public float hoverSize;
    public float hoverRotation;
    public float animSpeed;

    [Header("UI Text")]
    public TextMeshProUGUI text;
    public float textHoverRotation;

    public void Grow()
    {
        Debug.Log("grow");
        transform.LeanScale(new Vector2(hoverSize,hoverSize), animSpeed);
        transform.LeanRotate(new Vector3(0, 0, hoverRotation),animSpeed);
        if (!text) return;
        text.transform.LeanRotateZ(textHoverRotation, 0.5f).setEasePunch();
    }
    public void Shrink()
    {
        transform.LeanScale(new Vector2(1, 1), animSpeed);
        transform.LeanRotate(new Vector3(0, 0, 0), animSpeed);
        if (!text) return;
        text.transform.LeanRotateZ(0, 0.5f);
    }
}