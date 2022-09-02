using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Tilemaps;

public class LevelUISlot : MonoBehaviour
{
    private LevelSO levelData;
    [SerializeField] private TextMeshProUGUI levelNumberDisplay;
    [SerializeField] private Button thisLevelButton;

    void OnEnable()
    {
        thisLevelButton?.onClick.AddListener(LoadLevel);
    }

    void OnDisable()
    {
        thisLevelButton?.onClick.RemoveListener(LoadLevel);
    }

    public void SetLevelInfo(LevelSO thisLevel, int thisLevelNumber)
    {
        levelData = thisLevel;
        if (thisLevel)
        {
            levelNumberDisplay.text = thisLevelNumber.ToString();
            if(thisLevel.unlocked == false)
            {
                thisLevelButton.interactable = false;
            }
        }
    }

    public void LoadLevel()
    {
        CharacterMenuAnimation menuscene = FindObjectOfType<CharacterMenuAnimation>();
        menuscene.start = true;
        StartCoroutine(CharAnimMove());
    }

    IEnumerator CharAnimMove()
    {
        yield return new WaitForSeconds(4);
        GameHandler gameHandler = FindObjectOfType<GameHandler>();
        gameHandler.LoadLevel(levelData.levelNumber);
    }
}