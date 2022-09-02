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
    }

    void OnEnable()
    {
        resumeButton?.onClick.AddListener(Resume);
    }

    void OnDisable()
    {
        resumeButton?.onClick.RemoveListener(Resume);
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