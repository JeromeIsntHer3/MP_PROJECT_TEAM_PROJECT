using UnityEngine;
using TMPro;
using System;

public enum TimeStatus { TooEarly, Early, Perfect }

public class TimeHandler : MonoBehaviour
{

    public static TimeHandler instance;

    public bool pillEaten = false;
    private int cycles;

    [SerializeField]
    private float timeCycle;

    [SerializeField]
    private float tick;

    [SerializeField]
    private TextMeshProUGUI timeDisplay;

    [SerializeField]
    private PlayerData playerData;

    private float timeCountdown;
    private InventoryUI ui;

    void Awake()
    {
        instance = this;
        ui = FindObjectOfType<InventoryUI>();
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
                return TimeStatus.TooEarly;
        }
    }

    public void EatPill()
    {
        if (pillEaten)
        {
            playerData.inGamePlayerData.health -= 10;
        }
        pillEaten = true;
        ui.ChangeCurrentPill();
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

    void Update()
    {
        TimeCycle();
        if (TimeReset())
        {
            cycles += 1;
        }
    }
}