using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteMenu : MonoBehaviour
{
    public Button nextButton;
    public Button quitButton;

    void OnEnable()
    {
        nextButton?.onClick.AddListener(GoToNextLevel);
        quitButton?.onClick.AddListener(QuitToMenu);
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
}