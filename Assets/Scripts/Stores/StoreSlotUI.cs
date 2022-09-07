using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSlotUI : MonoBehaviour
{
    [SerializeField] private Image thisSlotImage;
    [SerializeField] private Button thisSlotButton;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Color defaultColor;

    private StoreUI thisStore;
    private ConsumableSO thisConsumable;
    private string thisDetails;
    private string thisPrice;

    void OnEnable()
    {
        thisSlotButton?.onClick.AddListener(SetInfoOnClick);
    }

    void OnDisable()
    {
        thisSlotButton?.onClick.RemoveListener(SetInfoOnClick);
    }

    public void SetSlot(ConsumableSO consumable, StoreUI parentManager)
    {
        if (consumable == null) return;
        thisStore = parentManager;
        thisConsumable = consumable;
        thisSlotImage.sprite = consumable.consumableSprite;
        thisSlotImage.color = Color.white;
        thisDetails = consumable.consumableDescription;
        thisPrice = consumable.consumablePrice.ToString();
    }

    public void Clear()
    {
        thisSlotImage.sprite = defaultSprite;
        thisSlotImage.color = Color.white;
        thisDetails = null;
        thisPrice = null;
        thisConsumable = null;
    }

    void SetInfoOnClick()
    {
        if (!thisConsumable) return;
        thisStore.OnClickSlot(thisDetails, thisPrice, thisConsumable);
    }
}