using System.Collections.Generic;
using System.ComponentModel.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MenusHandler : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenu;
    [SerializeField]private GameObject gameOver;
    [SerializeField]private GameObject levelComplete;
    [SerializeField]private GameObject settingsMenu;
    [SerializeField]private GameObject darkOverlay;

    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        if (Input.GetKeyDown(playerInput.pauseKey))
        {
            Pause();
        }
        if (TriggerZone.GameOver)
        {
            SetAllOff();
            darkOverlay.SetActive(true);
            gameOver.SetActive(true);
            PlayerInput.keysEnabled = false;
        }
        if (TriggerZone.LevelComplete)
        {
            SetAllOff();
            darkOverlay.SetActive(true);
            levelComplete.SetActive(true);
            PlayerInput.keysEnabled = false;
        }
    }

    void Pause()
    {
        SetAllOff();
        pauseMenu.SetActive(true);
        darkOverlay.SetActive(true);
    }

    public void Resume()
    {
        SetAllOff();
        darkOverlay.SetActive(false);
    }

    public void OpenSettings()
    {
        SetAllOff();
        settingsMenu.SetActive(true);
        darkOverlay.SetActive(true);
    }

    public void QuitToMenu()
    {
        SetAllOff();
        darkOverlay.SetActive(false);
        SceneManager.LoadScene("Menu_Demo");
    }

    public void Back()
    {
        SetAllOff();
        pauseMenu.SetActive(true);
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("In-Game_Demo");
    }

    void SetAllOff()
    {
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        levelComplete.SetActive(false);
        settingsMenu.SetActive(false);
    }
}