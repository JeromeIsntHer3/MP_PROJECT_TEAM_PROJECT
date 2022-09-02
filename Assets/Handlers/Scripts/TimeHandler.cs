using UnityEngine;
using TMPro;
using System;

public enum TimeStatus { TooEarly, Early, Perfect }

public class TimeHandler : MonoBehaviour
{

    public static TimeHandler instance;

    private bool pillEaten = false;
    private int cycles;

    [SerializeField]
    private float timeCycle;

    [SerializeField]
    private float tick;

    [SerializeField]
    private TextMeshProUGUI timeDisplay;

    private float timeCountdown;
    public float CurrentTime { get { return timeCountdown; } }

    void Awake()
    {
        instance = this;
    }

    public void OnEnable()
    {
        timeCountdown = timeCycle;
        cycles = 0;
        GameObject display = GameObject.Find("Time");
        if (!display) return;
        timeDisplay = display.transform.GetComponent<TextMeshProUGUI>();
    }

    void TimeCycle()
    {
        Debug.Log(pillEaten);
        if (!timeDisplay) return;
        if(timeCountdown == timeCycle)
        {
            pillEaten = false;
        }
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
    


    public TimeStatus TimeStat()
    {
        switch (timeCountdown)
        {
            case < 5:
                return TimeStatus.Perfect;
            case < 15:
                return TimeStatus.Early;
            case < 30:
                return TimeStatus.TooEarly;
            default:
                return TimeStatus.Perfect;
        }
    }

    public void StopTime()
    {
        timeCountdown = 0;
        tick = 0;
    }

    public void EatPill()
    {
        pillEaten = true;
    }

    public bool HasEatenPill()
    {
        return pillEaten;
    }

    public bool TimeReset()
    {
        return timeCountdown == timeCycle;
    }

    public int Cycles()
    {
        return cycles;
    }

    public void Update()
    {
        TimeCycle();
        if (TimeReset())
        {
            cycles += 1;
        }
    }
}