using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBuffSlot : MonoBehaviour
{
    [SerializeField] private Image durationOverlay;
    [SerializeField] private Image backdrop;
    private float maxDuration;
    private float currDuration;

    void Update()
    {
        if(currDuration > 0)
        {
            currDuration -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        durationOverlay.fillAmount = currDuration / maxDuration;
    }

    public void SetUpDisplayBuffSlot(string buffName, float duration, Sprite image)
    {
        gameObject.name = buffName;
        maxDuration = currDuration = duration;
        backdrop.sprite = durationOverlay.sprite = image;
    }

    public void AddTime(float time)
    {
        currDuration += time;
        maxDuration += time;
    }
}