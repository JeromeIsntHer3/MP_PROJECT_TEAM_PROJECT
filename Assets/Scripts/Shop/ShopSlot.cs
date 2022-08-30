using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour
{

    public Image thisImage;
    public Button thisSlot;
    private string thisDescription;
    private int thisPrice;

    private ConsumableSO thisConsumable;
    private Shop thisShop;

    void OnEnable()
    {
        thisSlot.onClick.AddListener(SetSlotShopInfo);
    }

    void OnDisable()
    {
        thisSlot.onClick.RemoveListener(SetSlotShopInfo);
    }

    public void SetShopSlot(ConsumableSO consumable, Shop manager)
    {
        thisConsumable = consumable;
        thisShop = manager;
        if (thisConsumable)
        {
            thisImage.sprite = consumable.consumableSprite;
            thisDescription = consumable.consumableDescription;
            thisPrice = consumable.consumablePrice;
        }
    }

    void SetSlotShopInfo()
    {
        thisShop.SetSelectedSlotShopInfo(thisDescription, thisPrice, thisConsumable);
    }
}