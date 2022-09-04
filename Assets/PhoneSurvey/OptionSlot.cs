using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionSlot : MonoBehaviour
{
    [SerializeField] private Button thisSlotButton;
    [SerializeField] private TextMeshProUGUI optionText;

    private Phone manager;
    private bool correct;

    void OnEnable()
    {
        thisSlotButton.onClick.AddListener(SelectOption);
    }

    void OnDisable()
    {
        thisSlotButton.onClick.RemoveListener(SelectOption);
    }

    void SelectOption()
    {
        manager.SelectedOptionResponse(correct);
    }

    public void SetOptionSlot(string option, bool correct, Phone manager)
    {
        this.correct = correct;
        this.manager = manager;
        optionText.text = option;
    }
}