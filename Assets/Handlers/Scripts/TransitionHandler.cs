using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public GameObject circleShadow;
    public Vector3 transitionScale;
    public float duration;
    public bool hasSceneTrasition;

    void OnEnable()
    {
        GameEvents.current.OnLoadLevel += LevelLoad;
    }

    void OnDisable()
    {
        GameEvents.current.OnLoadLevel -= LevelLoad;
    }

    void Awake()
    {
        if (!hasSceneTrasition)
        {
            circleShadow.transform.localScale = Vector3.zero;
        }
        else
        {
            circleShadow.transform.localScale = transitionScale;
            LeanTween.scale(circleShadow, Vector3.zero, duration);
        }
    }

    void LevelLoad(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    public IEnumerator LoadLevel(int sceneIndex)
    {
        LeanTween.scale(circleShadow, transitionScale, duration);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneIndex);
    }
}