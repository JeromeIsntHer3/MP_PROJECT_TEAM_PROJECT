using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image thisImage;
    public Button thisSlot;
    private string thisDescription;
    private string thisStatus;

    private ConsumableSO thisConsumable;
    private Inventory thisInventory;

    void OnEnable()
    {
        thisSlot.onClick.AddListener(SetSlotInventoryInfo);
    }

    void OnDisable()
    {
        thisSlot.onClick.RemoveListener(SetSlotInventoryInfo);
    }

    public void SetInventorySlot(ConsumableSO consumable, Inventory manager)
    {
        thisConsumable = consumable;
        thisInventory = manager;
        if (thisConsumable)
        {
            thisImage.sprite = consumable.consumableSprite;
            thisDescription = consumable.consumableDescription;
            thisStatus = consumable.consumableStatus;
        }
    }

    void SetSlotInventoryInfo()
    {
        thisInventory.SetSelectedSlotInventoryInfo(thisDescription,thisStatus,thisConsumable);
    }
}