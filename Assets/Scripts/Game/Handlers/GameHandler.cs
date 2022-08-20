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

    [Header("Notification Storage Data")]
    [SerializeField]
    private NotificationStorage network;
    [SerializeField]
    private NotificationStorage message;
    [SerializeField]
    private NotificationStorage medical;
    [SerializeField]
    private NotificationStorage info;

    void Start()
    {
        LoadData();
    }

    private void OnDestroy()
    {
        SaveData();
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
        for (int i = 1; i < levelHolder.Levels.Count; i++)
        {
            levelHolder.Levels[i].unlocked = false;
        }
        gameData.playerHealth = 100;

        LoopStorage(network);
        LoopStorage(message);
        LoopStorage(medical);
        LoopStorage(info);
    }

    void LoopStorage(NotificationStorage storage)
    {
        foreach(NotificationData data in storage.notificationList)
        {
            data.seen = false;
            if(data.notficationType != storage.storageType)
            {
                storage.notificationList.Remove(data);
            }
        }
    }
}