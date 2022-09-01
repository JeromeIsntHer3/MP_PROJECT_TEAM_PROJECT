using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [SerializeField] private Image thisSlotImage;
    private string thisDetails;
    private ConsumableSO thisConsumableSO;
    private InventoryUI thisParent;
    private Button thisSlotButton;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Color defaultColor;

    void OnEnable()
    {
        thisSlotButton = GetComponent<Button>();
        thisSlotButton.onClick.AddListener(SetInfoOnClick);
    }

    void OnDisable()
    {
        thisSlotButton.onClick.RemoveListener(SetInfoOnClick);
    }

    public void SetSlot(ConsumableSO consumable, InventoryUI parentManager)
    {
        if (consumable == null) return;
        thisParent = parentManager;
        thisConsumableSO = consumable;
        if (!consumable.inStoreSprite)
        {
            thisSlotImage.sprite = consumable.consumableSprite;
        }
        else
        {
            thisSlotImage.sprite = consumable.inStoreSprite;
        }
        thisSlotImage.color = Color.white;
        thisDetails = consumable.consumableDescription;
    }

    public void Clear()
    {
        thisSlotImage.sprite = defaultSprite;
        thisSlotImage.color = defaultColor;
        thisDetails = null;
        thisConsumableSO = null;
    }

    void SetInfoOnClick()
    {
        if (thisConsumableSO == null) return;
        thisParent.OnClickSlot(thisDetails, thisConsumableSO);
    }
}