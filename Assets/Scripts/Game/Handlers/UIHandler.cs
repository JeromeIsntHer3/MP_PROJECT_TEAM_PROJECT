using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System;

public class UIHandler : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject settingsMenu;

    [Header("Perspective UI")]
    [SerializeField]
    private GameObject realityUI;
    [SerializeField]
    private GameObject bodyUI;
    [SerializeField]
    private GameObject timeUI;

    [Header("Cameras")]
    [SerializeField]
    private GameObject camera_1;
    [SerializeField]
    private GameObject camera_2;

    private PlayerInput playerInput;
    private SoundManager soundManager;
    private bool swap;
    private bool gamePaused;
    private string SceneToLoad;

    void Start()
    {
        playerInput = FindObjectOfType<PlayerInput>();
        soundManager = FindObjectOfType<SoundManager>();
        SetAllOff();
        realityUI.SetActive(true);
        timeUI.SetActive(true);
    }

    void Update()
    {
        if (TriggerZone.GameOver == false)
        {
            if (!playerInput) return;
            if (Input.GetKeyDown(playerInput.swapKey))
            {
                SwapPerspective();
            }
            if (Input.GetKeyDown(playerInput.pauseKey) && !gamePaused)
            {
                Pause();
            }
        }
        else
        {
            GameOver();
        }
    }

    void SwapPerspective()
    {
        swap = !swap;
        if (!swap)
        {
            camera_1.SetActive(true);
            camera_2.SetActive(false);
            realityUI.SetActive(true);
            bodyUI.SetActive(false);
        }
        else
        {
            camera_1.SetActive(false);
            camera_2.SetActive(true);
            realityUI.SetActive(false);
            bodyUI.SetActive(true);
        }
    }

    #region General Functions
    public void Pause()
    {
        gamePaused = true;
        AnimateUI(pauseMenu,true,0.2f);
    }

    public void Unpause()
    {
        gamePaused = false;
        AnimateUI(pauseMenu, false, 0.2f);
    }

    public void GameOver()
    {
        SetAllOff();
        gameOver.SetActive(true);
    }

    void SetAllOff()
    {
        pauseMenu.SetActive(false);
        gameOver.SetActive(false);
        settingsMenu.SetActive(false);
        realityUI.SetActive(false);
        bodyUI.SetActive(false);
        timeUI.SetActive(false);
    }
    #endregion

    #region Pause Menu Functions
    public void Resume()
    {
        Unpause();
    }

    public void Settings()
    {
        AnimateUI(settingsMenu, true, 0.3f);
        AnimateUI(pauseMenu, false, 0.3f);
    }

    public void BackToPauseMenu()
    {
        AnimateUI(pauseMenu, true, 0.3f);
        AnimateUI(settingsMenu, false, 0.3f);
    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneToLoad = "Menu_Demo";
        AnimateUI(pauseMenu, false, 0.3f,LoadScene);
    }

    #endregion

    #region Defeat/GameOver Functions
    public void TryAgain()
    {
        TriggerZone.GameOver = false;
        Time.timeScale = 1;
        AnimateUI(gameOver, false, 0.1f, ReloadScene);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    #endregion

    #region Animation Function
    void LoadScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    void AnimateUI(GameObject go, bool active, float duration, Action func = null)
    {
        if (active)
        {
            StartCoroutine(WaitForAnimBefore(duration, go, func));
        }
        else
        {
            StartCoroutine(WaitForAnimAfter(duration, go, func));
        }
        soundManager.PlaySound(soundManager.buttonSound);
    }
    #endregion


    #region Coroutines
    IEnumerator WaitForAnimBefore(float time, GameObject go, Action func)
    {
        go.SetActive(true);
        go.transform.localScale = Vector2.zero;
        go.transform.LeanScale(Vector2.one, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        if (func != null) func();
    }
    IEnumerator WaitForAnimAfter(float time, GameObject go, Action func)
    {
        go.transform.LeanScale(Vector2.zero, time).setEaseInOutQuart().setIgnoreTimeScale(true);
        yield return new WaitForSeconds(time);
        go.SetActive(false);
        if(func != null) func();
    }
    #endregion
}