using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI bottomText;
    [SerializeField] private float transitionDuration;
    [SerializeField] private PopUpStorage popups;

    private int index = 0;
    private bool opened;

    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            opened = !opened;
            if (opened)
            {
                Close();
            }
            else
            {
                Open();
                ShowCurrentIndexPopUp();
            }
        }


        if (popups == null) return;
        if (Input.GetKeyDown(KeyCode.F))
        {
            index--;
            ShowCurrentIndexPopUp();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            index++;
            ShowCurrentIndexPopUp();
        }
    }

    void SetUpPopUp(PopUpSO popUp)
    {
        header.text = popUp.header;
        mainText.text = popUp.main;
        gameObject.LeanScale(new Vector3(1, 1, 1), transitionDuration).setEaseSpring();
    }

    void ShowCurrentIndexPopUp()
    {
        if (popups == null) return;
        index = Mathf.Clamp(index, 0, popups.popUps.Count - 1);
        SetUpPopUp(popups.popUps[index]);
        
        if (popups.popUps[index] == popups.popUps.Last())
        {
            bottomText.text = "'F' To Go Back     |     'X' To Close";
        }
        else
        {
            bottomText.text = "'F' To Go Back     |     'G' To Go Next";
        }
    }

    void Open()
    {
        index = 0;
        gameObject.LeanScale(new Vector3(1, 1, 1), transitionDuration).setEaseSpring();
    }

    void Close()
    {
        gameObject.LeanScale(new Vector3(0, 0, 0), transitionDuration).setEaseOutSine();
    }

    public void SetNewStorage(PopUpStorage popUpStorage)
    {
        popups = popUpStorage;
        ShowCurrentIndexPopUp();
    }
}