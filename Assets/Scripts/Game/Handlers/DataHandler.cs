using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHandler : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private LevelHolder levelHolder;
    [SerializeField] private LevelData currentLevel;
    [SerializeField] private LevelData nextLevel;

    public LevelData Getlevel()
    {
        return currentLevel;
    }

    [Header("Game Data")]
    public PersistantData gameData;

    [Header("Object References")]
    [SerializeField] private ResultHandler results;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private Player player;
    [SerializeField] private PlayerStats stats;

    [Header("Notification Storage Data")]
    [SerializeField] private NotificationStorage[] storages;

    public delegate void PickUp();
    public static PickUp OnPickUp;

    void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

    void OnEnable()
    {
        LoadData();
        TriggerZone.LevelCompleteEvent += UnlockNextLevel;
        TriggerZone.LevelCompleteEvent += UpdateResults;
    }

    void OnDisable()
    {
        SaveData();
        TriggerZone.LevelCompleteEvent -= UnlockNextLevel;
        TriggerZone.LevelCompleteEvent -= UpdateResults;
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
        SceneManager.LoadScene(nextLevel.sceneName);
    }

    public void ResetInfo()
    {
        for (int i = 1; i < levelHolder.Levels.Count; i++)
        {
            levelHolder.Levels[i].unlocked = false;
        }

        LoopStorage();

        if (OnPickUp == null) return;
        OnPickUp();
    }

    public void UpdateResults()
    {
        results.SetupResult(stats.GetInfectedDuration(),player.GetStat(TypeOfStat.Recovery).ToString(),stats.GetTimeInLevel());
    }

    void LoopStorage()
    {
        foreach (NotificationStorage storage in storages)
        {
            for (int i = 0;i < storage.notificationList.Count; i++)
            {
                storage.notificationList[i].seen = false;
                if(storage.notificationList[i].seen == false)
                {
                    storage.notificationList.RemoveAt(i);
                }
            }
        }
    }
}