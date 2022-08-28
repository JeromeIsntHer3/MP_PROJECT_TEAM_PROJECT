using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialChecks : MonoBehaviour
{
    [SerializeField] private GameObject warningDisplay;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
        //int played = PlayerPrefs.GetInt("HasPlayed");
        //if (played == 0)
        //{
        //    PlayerPrefs.SetInt("HasPlayed", 1);
        //    DisplayWarning();
        //}
        //else
        //{
        //    Close();
        //}
    }

    void DisplayWarning()
    {
        warningDisplay.SetActive(true);
    }

    public void Close()
    {
        warningDisplay.SetActive(false);
    }
}