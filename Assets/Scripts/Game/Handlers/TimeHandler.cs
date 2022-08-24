using UnityEngine;
using TMPro;
using System;

public class TimeHandler : MonoBehaviour
{

    public static TimeHandler instance;

    [SerializeField]
    private float timeCycle;

    [SerializeField]
    private float tick;

    [SerializeField]
    private TextMeshProUGUI timeDisplay;

    private float timeCountdown;
    public float TimeCountDown { get { return timeCountdown; } }

    void Awake()
    {
        instance = this;
    }

    public void OnEnable()
    {
        timeCountdown = timeCycle;
        GameObject display = GameObject.Find("Time");
        if (!display) return;
        timeDisplay = display.transform.GetComponent<TextMeshProUGUI>();
    }

    void TimeCycle()
    {
        if (!timeDisplay) return;
        if (timeCountdown > 0)
        {
            timeCountdown -= tick * Time.deltaTime;
        }
        if (timeCountdown <= 0)
        {
            timeCountdown = timeCycle;
        }
        TimeSpan timePlaying = TimeSpan.FromSeconds(timeCountdown);
        string timeString = timePlaying.ToString("mm':'ss");
        timeDisplay.text = timeString;
    }

    public void StopTime()
    {
        timeCountdown = 0;
        tick = 0;
    }

    public void Update()
    {
        TimeCycle();
    }
}