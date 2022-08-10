using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField]
    private LevelHolder levelHolder;
    public LevelData thisLevel;

    public PersistantData gameData;

    [SerializeField]
    private SoundManager soundManager;
    [SerializeField]
    private Player player;

    void Start()
    {
        LoadData();
    }

    void LoadData()
    {
        soundManager.fxSlider.value = gameData.fxVolume;
        soundManager.musicSlider.value = gameData.musicVolume;
        if (!player) return;
        player.CurrHealth = gameData.playerHealth;
        player.CurrProgress = gameData.playerProgress;
        Debug.Log("Data Loaded");
    }

    public void SaveData()
    {
        gameData.fxVolume = soundManager.fxSlider.value;
        gameData.musicVolume = soundManager.musicSlider.value;
        if (!player) return;
        gameData.playerHealth = player.CurrHealth;
        gameData.playerProgress = player.CurrProgress;
        Debug.Log("Data Saved");
    }

    public void UnlockNextLevel()
    {
        if (levelHolder.Levels.Contains(thisLevel))
        {
            int index = levelHolder.Levels.IndexOf(thisLevel);
            levelHolder.Levels[index + 1].unlocked = true;
        }
    }

    public void ResetInfo()
    {
        for(int i = 1; i < levelHolder.Levels.Count; i++)
        {
            levelHolder.Levels[i].unlocked = false;
        }
        gameData.playerHealth = 100;
    }

    private void OnDestroy()
    {
        SaveData();
    }
}