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

    private int totalScore;

    void OnEnable()
    {
        nextButton?.onClick.AddListener(GoToNextLevel);
        quitButton?.onClick.AddListener(QuitToMenu);
        ShowResults();
    }

    void Start()
    {
        GameHandler.instance.gameRunning = false;
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
        coinsText.text = GameHandler.instance.CoinsCollected().ToString();
        pillsText.text = GameHandler.instance.PillsMissed().ToString();
        TimeSpan timePlaying = TimeSpan.FromSeconds(GameHandler.instance.TimeToComplete());
        string timeString = timePlaying.ToString("mm':'ss");
        timeTakenText.text = timeString;
    }
}