using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour
{
    [SerializeField] private Button nextButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI pillsText;
    [SerializeField] private TextMeshProUGUI timeTakenText;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private PlayerData playerData;

    void OnEnable()
    {
        nextButton?.onClick.AddListener(GoToNextLevel);
        quitButton?.onClick.AddListener(QuitToMenu);
        ShowResults();
    }

    void OnDisable()
    {
        nextButton?.onClick.RemoveListener(GoToNextLevel);
        quitButton?.onClick.RemoveListener(QuitToMenu);
    }

    void GoToNextLevel()
    {
        
    }

    void QuitToMenu()
    {
        GameEvents.current.LoadLevel(0);
    }

    void ShowResults()
    {
        coinsText.text = playerData.inGamePlayerData.currency.ToString();
        pillsText.text = playerData.inGamePlayerData.pillsNotEaten.ToString();
        TimeSpan timePlaying = TimeSpan.FromSeconds(playerData.inGamePlayerData.timePlayed);
        string timeString = timePlaying.ToString("mm':'ss");
        timeTakenText.text = timeString;

        float coinGrade = (playerData.inGamePlayerData.currency * 100);
        float pillGrade = 100 - ((playerData.inGamePlayerData.pillsNotEaten / 10) * 100);
        float timeGrade = 100 - ((playerData.inGamePlayerData.timePlayed / 900) * 100);

        float finalGrade = (coinGrade + pillGrade + timeGrade) / 300 * 100;

        switch (finalGrade)
        {
            case <= 25:
                resultText.text = "D";
                break;
            case <= 40:
                resultText.text = "D+";
                break;
            case <= 55:
                resultText.text = "C";
                break;
            case <= 65:
                resultText.text = "C+";
                break;
            case <= 75:
                resultText.text = "B";
                break;
            case <= 85:
                resultText.text = "B+";
                break;
            case <= 90:
                resultText.text = "A";
                break;
            case <= 100:
                resultText.text = "S";
                break;
        }
    }
}