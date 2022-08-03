using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonAnim : MonoBehaviour
{
    public float increasedSize;
    public float animSpeed;
    public TextMeshProUGUI text;

    public void Grow()
    {
        transform.LeanScale(new Vector2(increasedSize,increasedSize), animSpeed);
        transform.LeanRotate(new Vector3(0, 0, 1),animSpeed);
        if (!text) return;
        text.transform.LeanRotateZ(0, 0.5f).setEaseShake();
    }
    public void Shrink()
    {
        transform.LeanScale(new Vector2(1, 1), animSpeed);
        transform.LeanRotate(new Vector3(0, 0, 0), animSpeed);
    }
}