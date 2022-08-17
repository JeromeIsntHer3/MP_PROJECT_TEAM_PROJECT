using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField]
    private LevelHolder levelHolder;
    [SerializeField]
    private GameObject levelPrefab;
    [SerializeField]
    private GameObject levelPanel;
    

    void OnEnable()
    {
        SetUpLevels();
    }

    void OnDisable()
    {
        ClearLevels();
    }

    void SetUpLevels()
    {
        for(int i = 0;i < levelHolder.Levels.Count;i++)
        {
            GameObject temp = Instantiate(levelPrefab, levelPanel.transform.position, levelPanel.transform.rotation, levelPanel.transform);
            Level thisLevel = temp.GetComponent<Level>();
            if (thisLevel)
            {
                thisLevel.SetLevelInfo(levelHolder.Levels[i], levelHolder.Levels.IndexOf(levelHolder.Levels[i]) + 1);
            }
            if (levelHolder.Levels[i].unlocked)
            {
                thisLevel.gameObject.SetActive(true);
            }
            else
            {
                thisLevel.gameObject.SetActive(false);
            }
        }
    }

    void ClearLevels()
    {
        for(int i = 0; i < levelPanel.transform.childCount;i++)
        {
            Destroy(levelPanel.transform.GetChild(i).gameObject);
        }
    }
}