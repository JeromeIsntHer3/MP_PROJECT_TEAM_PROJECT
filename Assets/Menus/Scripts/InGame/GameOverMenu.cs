using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Button tryButton;
    [SerializeField] private Button quitButton;

    void OnEnable()
    {
        tryButton.onClick.AddListener(TryAgain);
        quitButton.onClick.AddListener(QuitToMenu);
    }

    void OnDisable()
    {
        tryButton.onClick.RemoveListener(TryAgain);
        quitButton.onClick.RemoveListener(QuitToMenu);
    }

    void TryAgain()
    {

    }

    void QuitToMenu()
    {
        GameEvents.current.LoadLevel(0);
    }
}