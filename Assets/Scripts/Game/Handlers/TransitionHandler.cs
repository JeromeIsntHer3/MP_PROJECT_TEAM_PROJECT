using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionHandler : MonoBehaviour
{
    public GameObject circleShadow;
    public Vector3 transitionScale;
    public float duration;

    void Awake()
    {
        circleShadow.transform.localScale = transitionScale;
        LeanTween.scale(circleShadow, Vector3.zero, duration);
    }

    public IEnumerator LoadLevel(string nextSceneName)
    {
        LeanTween.scale(circleShadow, transitionScale, duration);
        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(nextSceneName);
    }
}