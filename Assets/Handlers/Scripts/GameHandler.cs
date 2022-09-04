using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [Header("Game Data")]
    [SerializeField] private PersistantData gameData;

    [Header("Player")]
    private Player player;

    [Header("Settings")]
    private SoundManager soundManager;

    void Awake()
    {
        player = FindObjectOfType<Player>();
        soundManager = transform.GetComponentInChildren<SoundManager>();
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
        //Load in Settings Data
        soundManager.fxSlider.value = gameData.fxVolume;
        soundManager.musicSlider.value = gameData.musicVolume;

        if (!player) return;
        //If Player exists, load Player Data
        player.SetStat(TypeOfStat.Health, gameData.playerHealth);
        player.SetStat(TypeOfStat.Recovery, gameData.playerRecovery);
        player.SetStat(TypeOfStat.Infection, gameData.playerInfection);
        Debug.Log("Data Loaded");
    }

    public void SaveData()
    {
        //Save Settings Data
        gameData.fxVolume = soundManager.fxSlider.value;
        gameData.musicVolume = soundManager.musicSlider.value;

        if (!player) return;
        //If Player exists, save Player Data
        gameData.playerHealth = player.GetStat(TypeOfStat.Health);
        gameData.playerRecovery = player.GetStat(TypeOfStat.Recovery);
        gameData.playerInfection = player.GetStat(TypeOfStat.Infection);
        Debug.Log("Data Saved");
    }

    public void UnlockLevel(LevelSO levelToUnlock)
    {
        levelToUnlock.unlocked = true;
    }
}