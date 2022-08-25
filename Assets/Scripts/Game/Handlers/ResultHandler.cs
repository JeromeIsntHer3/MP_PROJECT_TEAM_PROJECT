using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeInfectedText;
    [SerializeField] private TextMeshProUGUI recoveryText;
    [SerializeField] private TextMeshProUGUI timeTakenText;
    [SerializeField] private TextMeshProUGUI gradeText;

    [SerializeField] private PlayerStats stats;
    [SerializeField] private Player player;

    void OnEnable()
    {
        TriggerZone.LevelCompleteEvent += SetupResult;
    }

    void OnDisable()
    {
        TriggerZone.LevelCompleteEvent -= SetupResult;
    }

    void SetupResult()
    {
        timeInfectedText.text = TimeSpan.FromSeconds(stats.InfectedDuration()).ToString("mm':'ss");
        recoveryText.text = player.GetStat(TypeOfStat.Recovery).ToString() + "%";
        timeTakenText.text = TimeSpan.FromSeconds(stats.TimeInLevel()).ToString("mm':'ss");
        gradeText.text = SetupGrade();
    }

    string SetupGrade()
    {
        float infectedDur = stats.InfectedDuration();
        float timeTaken = stats.TimeInLevel();
        float recovery = player.GetStat(TypeOfStat.Recovery);

        int points = 0;

        switch (infectedDur)
        {
            case <5:
                points += 10;
                break;
            case < 10:
                points += 8;
                break;
            case < 15:
                points += 5;
                break;
            case < 20:
                points += 3;
                break;
            default:
                points += 1;
                break;
        }

        switch (timeTaken)
        {
            case < 30:
                points += 10;
                break;
            case < 45:
                points += 8;
                break;
            case < 60:
                points += 5;
                break;
            case < 90:
                points += 3;
                break;
            default:
                points += 1;
                break;
        }

        switch (recovery)
        {
            case >= 85:
                points += 10;
                break;
            case >= 70:
                points += 8;
                break;
            case >= 50:
                points += 5;
                break;
            case >= 30:
                points += 3;
                break;
            default:
                points += 1;
                break;
        }

        switch (points)
        {
            case >= 25:
                return "A";
            case >= 20:
                return "B";
            case >= 10:
                return "C";
            default:
                return "D";
        }
    }
}