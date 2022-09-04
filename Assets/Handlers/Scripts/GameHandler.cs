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
    private Inventory playerInventory;

    [Header("Settings")]
    private SoundManager soundManager;

    private int questionAnsweredCorrectly;
    private int pillsMissed;
    private float timeSinceStart;
    public bool gameRunning;


    void Awake()
    {
        instance = this;

        player = FindObjectOfType<Player>();
        playerInventory = player.GetComponent<Inventory>();
        soundManager = transform.GetComponentInChildren<SoundManager>();


        questionAnsweredCorrectly = 0;
        timeSinceStart = 0;
        pillsMissed = 0;
        gameRunning = true;
    }

    void OnEnable()
    {
        LoadData();
    }

    void OnDisable()
    {
        
    }

    void Update()
    {
        if (gameRunning)
        {
            timeSinceStart += 1 * Time.deltaTime;
        }
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
        //Player Inventory
        playerInventory.SetCurrency(gameData.playerCoins);
        Debug.Log("Data Loaded");
    }

    public void SaveCurrentData()
    {
        //Save Settings Data
        gameData.fxVolume = soundManager.fxSlider.value;
        gameData.musicVolume = soundManager.musicSlider.value;

        if (!player) return;
        //If Player exists, save Player Data
        gameData.playerHealth = player.GetStat(TypeOfStat.Health);
        gameData.playerRecovery = player.GetStat(TypeOfStat.Recovery);
        gameData.playerInfection = player.GetStat(TypeOfStat.Infection);
        //Player Inventory
        gameData.playerCoins = playerInventory.GetCurrency();
        Debug.Log("Data Saved");
    }

    public void MissedPill()
    {
        pillsMissed++;
    }

    public int PillsMissed()
    {
        return pillsMissed;
    }

    public void AnsweredCorrectly()
    {
        questionAnsweredCorrectly++;
    }

    public int QuestionsAnsweredCorrectly()
    {
        return questionAnsweredCorrectly;
    }

    public int CoinsCollected()
    {
        return playerInventory.GetCurrency();
    }

    public float TimeToComplete()
    {
        return timeSinceStart;
    }

    public void UnlockLevel(LevelSO levelToUnlock)
    {
        levelToUnlock.unlocked = true;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetToDefaultStats()
    {
        gameData.playerHealth = gameData.defaultHealth;
        gameData.playerInfection = gameData.defaultInfection;
        gameData.playerRecovery = gameData.defaultRecovery;
        gameData.fxVolume = gameData.musicVolume = gameData.defaultVolume;
        gameData.playerCoins = gameData.defaultCoins;
    }
}