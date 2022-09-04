using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private Transform displayParent;
    [SerializeField] private Vector3 onScreenPosition;
    [SerializeField] private Vector3 offScreenPosition;
    [SerializeField] private float animDurr;
    [SerializeField] private Transform uiElementParent;
    [SerializeField] private GameObject questionAnswered;
    [SerializeField] private QuestionStorageSO questions;

    private RectTransform thisTransform;
    private QuestionSO currQuestion;

    void Awake()
    {
        thisTransform = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        SetUpPhone(true);
        SetUpSlots();
    }

    void OnDisable()
    {
        
    }

    void SetUpSlots()
    {
        OptionSlot[] optionSlots = displayParent.GetComponentsInChildren<OptionSlot>();
        if (optionSlots.Length == 0) return;
        for (int i = 0; i < optionSlots.Length - 1; i++)
        {
            optionSlots[i].SetOptionSlot(currQuestion.options[i],currQuestion.correctOrWrong[i], this);
        }
    }

    void SetUpPhone(bool active)
    {
        int question = Random.Range(0, questions.Questions.Count);
        while (questions.Questions[question].answered) 
        {
            if(question < questions.Questions.Count)
            {
                question++;
            }
            else
            {
                question = 0;
            }
        }

        currQuestion = questions.Questions[question];
        this.question.text = currQuestion.question;

        for (int i = 0; i < uiElementParent.childCount; i++)
        {
            uiElementParent.GetChild(i).gameObject.SetActive(active);
        }
        questionAnswered.SetActive(!active);
        LeanTween.move(thisTransform, onScreenPosition, animDurr);
    }

    public void SelectedOptionResponse(bool isCorrect)
    {
        if (isCorrect)
        {
            Debug.Log("correct Answer");
            GameHandler.instance.AnsweredCorrectly();
        }
        StartCoroutine(ThankYouForAnswerin());
    }

    IEnumerator ThankYouForAnswerin()
    {
        SetUpPhone(false);
        yield return new WaitForSeconds(2);
        LeanTween.move(thisTransform, offScreenPosition, animDurr);
        gameObject.SetActive(false);
    }
}