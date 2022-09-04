using System.Collections;
using UnityEngine;
using TMPro;

public class PopUpHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI mainText;
    [SerializeField] private TextMeshProUGUI bottomText;
    [SerializeField] private float transitionDuration;
    [SerializeField] private PopUpStorage popStorage;

    private int index = 0;
    private bool opened;
    private bool dialogueCompleted;

    void Start()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if (popStorage == null) return;

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

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsFirstPopUp() && dialogueCompleted)
            {

            }
            else if(dialogueCompleted)
            {
                index--;
                ShowCurrentIndexPopUp();
            }
            else
            {
                SkipWrite();
            }
        }


        if (Input.GetKeyDown(KeyCode.G))
        {
            if (IsLastPopUp() && dialogueCompleted)
            {
                Close();
                PlayerInput.keysEnabled = true;
            }
            else if(dialogueCompleted)
            {
                index++;
                ShowCurrentIndexPopUp();
            }
            else
            {
                SkipWrite();
            }
        }
    }

    void ShowCurrentIndexPopUp()
    {
        PlayerInput.keysEnabled = false;
        index = Mathf.Clamp(index, 0, popStorage.popUps.Count - 1);
        PopUpSO currPopUp = popStorage.popUps[index];
        header.text = currPopUp.headerText;
        StopAllCoroutines();
        StartCoroutine(WriteText(currPopUp.mainText, mainText));
        gameObject.LeanScale(new Vector3(1, 1, 1), transitionDuration).setEaseSpring();
        
        if (IsLastPopUp())
        {
            bottomText.text = "'F' To Go Back     |     'G' To Close";
        }
        else
        {
            bottomText.text = "'F' To Go Back     |     'G' To Go Next";
        }
    }

    bool IsFirstPopUp()
    {
        return popStorage.popUps[index] == popStorage.popUps[0];
    }

    bool IsLastPopUp()
    {
        return index == popStorage.popUps.Count-1;
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
        popStorage = popUpStorage;
        index = 0;
        ShowCurrentIndexPopUp();
    }

    IEnumerator WriteText(string inputText,TextMeshProUGUI outputText)
    {
        outputText.text = "";
        dialogueCompleted = false;

        for (int i = 0; i < inputText.Length; i++)
        {
            outputText.text += inputText[i];
            yield return new WaitForSeconds(0.01f);
        }
        dialogueCompleted = true;
    }

    void SkipWrite()
    {
        StopAllCoroutines();
        mainText.text = "";
        mainText.text = popStorage.popUps[index].mainText;
        dialogueCompleted = true;
    }
}