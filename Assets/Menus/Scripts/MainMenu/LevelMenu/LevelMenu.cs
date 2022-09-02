using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : Menu
{
    [SerializeField] private Button back;
    [SerializeField] private List<LevelSO> levelStorage;
    [SerializeField] private GameObject levelUISlotPrefab;
    [SerializeField] private GameObject levelParentPanel;


    void OnEnable()
    {
        back?.onClick.AddListener(ToBack);
        UpdateLevelSlots();
    }

    void OnDisable()
    {
        back?.onClick.RemoveListener(ToBack);
    }

    void ToBack()
    {
        MenuManager.GoTo(TypeOfMenu.Main, gameObject);
    }

    void UpdateLevelSlots()
    {
        ClearLevelSlots();
        SetUpLevelSlots();
    }

    void SetUpLevelSlots()
    {
        for(int i = 0; i < levelStorage.Count; i++)
        {
            GameObject temp = Instantiate(levelUISlotPrefab, levelParentPanel.transform.position,
                levelParentPanel.transform.rotation, levelParentPanel.transform);
            LevelUISlot thisLevel = temp.GetComponent<LevelUISlot>();
            if (thisLevel)
            {
                thisLevel.SetLevelInfo(levelStorage[i], levelStorage[i].levelNumber);
            }
        }
    }

    void ClearLevelSlots()
    {
        for (int i = 0; i < levelParentPanel.transform.childCount; i++)
        {
            Destroy(levelParentPanel.transform.GetChild(i).gameObject);
        }
    }
}