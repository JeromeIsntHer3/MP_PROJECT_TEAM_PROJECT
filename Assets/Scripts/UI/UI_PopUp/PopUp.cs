using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField]
    private TextMeshProUGUI textObj;
    [SerializeField]
    private float textShownDuration;
    [SerializeField]
    private float transitionDuration;

    private RectTransform popUpTransform;

    void Start()
    {
        popUpTransform = GetComponent<RectTransform>();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            gameObject.LeanScale(new Vector3(0, 0, 0), transitionDuration).setEaseOutSine();
        }
    }

    public void SetUpPopUp(Vector3 position,Vector3 size, string text)
    {
        popUpTransform.localPosition = position;
        popUpTransform.sizeDelta = size;
        textObj.text = text;
        gameObject.LeanScale(new Vector3(1, 1, 1), transitionDuration).setEaseSpring();
    }
}