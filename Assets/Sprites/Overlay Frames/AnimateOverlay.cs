using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimateOverlay : MonoBehaviour
{
    [SerializeField]
    Image overlayImage;
    [SerializeField]
    Sprite[] OverlayFrames;
    int index;

    void OnEnable()
    {
        InvokeRepeating("ChangeFrame", Time.deltaTime, 0.3f);
    }

    void ChangeFrame()
    {
        if(index >= OverlayFrames.Length - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        overlayImage.sprite = OverlayFrames[index];
    }
}