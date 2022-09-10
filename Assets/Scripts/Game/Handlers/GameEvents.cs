using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current { get; private set; }

    void Awake()
    {
        if (current == null)
        {
            current = this;
        }
    }

    public event Action OnGameComplete;
    public void GameComplete()
    {
        if(OnGameComplete != null)
        {
            OnGameComplete();
        }
    }

    public event Action OnGameOver;
    public void GameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public event Action<int> OnLoadLevel;
    public void LoadLevel(int level)
    {
        if(OnLoadLevel != null)
        {
            OnLoadLevel(level);
        }
    }
}