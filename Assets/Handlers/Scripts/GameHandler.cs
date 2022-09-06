using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;

    [Header("Game Data")]
    [SerializeField] private PlayerData playerData;
    [SerializeField] private SettingsData settingsData;
 
    [Header("Player")]
    private Player player;
    private Inventory playerInventory;

    [Header("Settings")]
    private SoundManager soundManager;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        

        player = FindObjectOfType<Player>();
        if(player != null) playerInventory = player.GetComponent<Inventory>();
        soundManager = transform.GetComponentInChildren<SoundManager>();
    }

    void OnEnable()
    {
        LoadData();
    }

    void OnDisable()
    {
        
    }

    void LoadData()
    {
        //Load in Settings Data
        soundManager.effectsSlider.value = settingsData.inGameSettingsData.effectsVolume;
        soundManager.musicSlider.value = settingsData.inGameSettingsData.musicVolume;

        if (!player) return;
        //If Player exists, load Player Data
        player.SetStat(TypeOfStat.Health, playerData.inGamePlayerData.health);
        player.SetStat(TypeOfStat.Recovery, playerData.inGamePlayerData.recovery);
        player.SetStat(TypeOfStat.Infection, playerData.inGamePlayerData.infection);
        //Player Inventory
        Debug.Log("Data Loaded");
    }

    public void SaveCurrentData()
    {
        //Save Settings Data
        settingsData.inGameSettingsData.effectsVolume = soundManager.effectsSlider.value;
        settingsData.inGameSettingsData.musicVolume = soundManager.musicSlider.value;

        if (!player) return;
        //If Player exists, save Player Data
        playerData.inGamePlayerData.health = player.GetStat(TypeOfStat.Health);
        playerData.inGamePlayerData.recovery = player.GetStat(TypeOfStat.Recovery);
        playerData.inGamePlayerData.infection = player.GetStat(TypeOfStat.Infection);
        //Player Inventory
        Debug.Log("Data Saved");
    }

    public void UnlockLevel(LevelSO levelToUnlock)
    {
        levelToUnlock.unlocked = true;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetToDefaultStats()
    {
        //Player
        playerData.inGamePlayerData.health = playerData.defaultPlayerData.d_health;
        playerData.inGamePlayerData.recovery = playerData.defaultPlayerData.d_recovery;
        playerData.inGamePlayerData.infection = playerData.defaultPlayerData.d_infection;
        //Settings
        settingsData.inGameSettingsData.effectsVolume = settingsData.defaultSettingsData.d_effectsVolume;
        settingsData.inGameSettingsData.musicVolume = settingsData.defaultSettingsData.d_musicVolume;
    }
}