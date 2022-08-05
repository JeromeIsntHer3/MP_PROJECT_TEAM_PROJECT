using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    //We're not gonna do a singleton

    //VARIABLES
    private string cachedData = "";
    private float cachedHealth = 0;

    private string levelDataFormat = "LVL-";

 

    //PUBLIC FUNCTIONS
    public void ChangeScene(string _scene)
    {
        //Checks if the scene exists
        if (SceneManager.GetSceneByName(_scene) == null) { return; }

        SceneManager.LoadScene(_scene);
    }

    //Current things to store : Levels Completed / Current
    //Player Health
    //TBC On other stats
    //Structure of Data - lvl-0000

    //P.S Keep scene levels as Level_ID for DirSearch purposes

    public bool SavePlayerData()
    {
        if (cachedData.Length <= 0) { return false; }

        PlayerPrefs.SetFloat("Health", cachedHealth);
        PlayerPrefs.SetString("Levels", cachedData);

        return true;
    }

    public float GetHealthFromData()
    {
        return cachedHealth;
    }

    public bool GetLevelClearStatus(int _level)
    {
        if (cachedData.Length <= 0)
        {
            WarnPrint("LEVEL DATA IS BLANK");
            return false;
        }
        string separatedData = cachedData.Substring(levelDataFormat.Length);
        string levelBool = "" + separatedData[_level];

        print(string.Format("Level {0} Clear Status : {1}", _level, levelBool));

        switch (levelBool)
        {
            case "0":
                return false;

            case "1":
                return true;

            default:
                WarnPrint("WHY DOES THE DATA FORMAT HAVE NON-BOOLEAN NUMBERS?!?");
                return false;
        }
    }

    public void SetLevelClearStatus(int _level, bool _status)
    {
        string separatedData = cachedData.Substring(levelDataFormat.Length);
        string newData = "";

        int intStatus;

        if (_status == false)
        {
            intStatus = 0;
        } else
        {
            intStatus = 1;
        }

        for (int i=0; i < separatedData.Length; i++)
        {
            if (i == _level)
            {
                newData += intStatus;
            }
            else
            {
                newData += separatedData[i];
            }
        }

        cachedData = levelDataFormat + newData;
        print(cachedData);
    }

    //PRIVATE FUNCTIONS

    private void Start()
    {
        //We're lazy so we're going to just prevent the deload of the game manager game object
        DontDestroyOnLoad(this.gameObject);

        bool loadStatus = LoadPlayerData();

        //TESTING//
        cachedData = "LVL-101";
        print(GetLevelClearStatus(0));
        SetLevelClearStatus(1, true);
        print(GetLevelClearStatus(1));
        //////////
    }

    private bool LoadPlayerData()
    {
        float health;
        string levelData;
        WarnPrint("LOADING PLAYER DATA");

        if (PlayerPrefs.HasKey("Health") && PlayerPrefs.HasKey("Levels"))
        {
            //Load existing data
            health = PlayerPrefs.GetFloat("Health");
            levelData = PlayerPrefs.GetString("Levels");

        } else
        {
            //Construct new Data
            health = 100f; //Default Health
            levelData = ConstructLevelData();
        }

        cachedHealth = health;
        cachedData = levelData;

        print(string.Format("Level Loaded | Health : {0} | LevelData : {1}", health, levelData));

        return (levelData.Length > 0 && health > 0);
    }

    private int GetLevelCount()
    {
        WarnPrint("GETTING UNITY FILES IN LEVELS FOLDER");
        string levelFolderName = Application.dataPath + "/Scenes/SceneLevels";
        var folderInfo = new DirectoryInfo(levelFolderName);
        var allFolderInfo = folderInfo.GetFiles("*.mat", SearchOption.AllDirectories); //SET TO .MAT FOR TESTING, RETURN TO .UNITY

        int i = 0;
        foreach (var _scene in allFolderInfo)
        {
            print("Scene Levels Found : " + _scene.FullName);
            i++;
        }

        if (i == 0)
        {
            WarnPrint("NO SCENES FOUND IN LEVEL FOLDER");
        }

        return i;
    }

    private string ConstructLevelData()
    {
        WarnPrint("CONSTRUCTING NEW LEVEL DATA");
        int levels = GetLevelCount();
        string levelStruct = levelDataFormat;

        for (int i=0; i < levels; i++)
        {
            levelStruct += "0";
        }
        return levelStruct;
    }

    private void WarnPrint(string _warn)
    {
        Debug.LogWarning(string.Format("// {0} //", _warn));
    }
}
