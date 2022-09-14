using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject levelComplete;
    [SerializeField] private Button resumeButton;

    private PlayerInput playerInput;

    void Awake()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        MenuManager.Initialise();
    }

    void OnEnable()
    {
        resumeButton?.onClick.AddListener(Resume);
    }

    void Start()
    {
        GameEvents.current.OnGameComplete += GameCompleted;
        GameEvents.current.OnGameOver += GameEnded;
    }

    void OnDisable()
    {
        resumeButton?.onClick.RemoveListener(Resume);
        GameEvents.current.OnGameComplete -= GameCompleted;
        GameEvents.current.OnGameOver -= GameEnded;
    }

    void GameCompleted()
    {
        levelComplete.SetActive(true);
    }

    void GameEnded()
    {
        gameOver.SetActive(true);
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(playerInput.pauseKey))
        {
            if (!pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
            }
            else
            {
                pauseMenu.SetActive(false);
            }
        }
    }
}