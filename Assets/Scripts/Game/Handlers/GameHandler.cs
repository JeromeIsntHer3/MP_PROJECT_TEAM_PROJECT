using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [Header("Level Information")]
    [SerializeField] private LevelData currentLevel;
    [SerializeField] private LevelData nextLevel;

    [Header("Game Data")]
    [SerializeField] private PersistantData gameData;

    [Header("Player")]
    private Player player;

    [Header("Settings")]
    private SoundManager soundManager;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    void OnEnable()
    {
        LoadData();
    }

    void OnDisable()
    {
        SaveData();
    }

    void LoadData()
    {
        LoadSettingsData();
        if (!player) return;
        LoadPlayerData(gameData.playerHealth, gameData.playerRecovery, gameData.playerInfection);
        Debug.Log("Data Loaded");
    }

    public void SaveData()
    {
        SaveSettingsData();
        if (!player) return;
        SavePlayerData();
        Debug.Log("Data Saved");
    }

    void SavePlayerData()
    {
        gameData.playerHealth = player.GetStat(TypeOfStat.Health);
        gameData.playerRecovery = player.GetStat(TypeOfStat.Recovery);
        gameData.playerInfection = player.GetStat(TypeOfStat.Infection);
    }

    void LoadPlayerData(float health, float recovery, float infection)
    {
        player.SetStat(TypeOfStat.Health, health);
        player.SetStat(TypeOfStat.Recovery, recovery);
        player.SetStat(TypeOfStat.Infection, infection);
    }

    void SaveSettingsData()
    {
        gameData.fxVolume = soundManager.fxSlider.value;
        gameData.musicVolume = soundManager.musicSlider.value;
    }

    void LoadSettingsData()
    {
        soundManager.fxSlider.value = gameData.fxVolume;
        soundManager.musicSlider.value = gameData.musicVolume;
    }

    public void UnlockNextLevel()
    {
        nextLevel.unlocked = true;
    }

    public void LoadNextLevel()
    {
        
    }
}