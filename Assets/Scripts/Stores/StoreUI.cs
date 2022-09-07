using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    [Header("Storage Objects")]
    [SerializeField] private Store store;
    [SerializeField] private GameObject storeUI;
    [SerializeField] private Transform contentPanel;

    [Header("Buttons")]
    [SerializeField] private Button buyItem;

    [Header("Slot Clicked Info")]
    [SerializeField] private TextMeshProUGUI details;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI chat;
    [SerializeField] private ConsumableSO selectedConsumable;

    [SerializeField] private GameObject survey;

    private StoreSlotUI[] storeSlots;

    void OnEnable()
    {
        store.storeChanged += UpdateSlots;

        buyItem?.onClick.AddListener(Buy);

        storeSlots = contentPanel.GetComponentsInChildren<StoreSlotUI>();
        UpdateSlots();
        chat.text = "Welcome, feel free to look at my wares.";
    }

    void OnDisable()
    {
        store.storeChanged -= UpdateSlots;

        buyItem?.onClick.RemoveListener(Buy);

        if(survey != null) survey.SetActive(true);
    }

    void UpdateSlots()
    {
        ClearSlots();
        SetUpSlots();
        details.text = "";
        price.text = "";
    }

    void SetUpSlots()
    {
        for (int i = 0; i < store.GetStoreStorage().consumableSOs.Count; i++)
        {
            storeSlots[i].SetSlot(store.GetStoreStorage().consumableSOs[i], this);
        }
    }

    void ClearSlots()
    {
        for (int i = 0; i < storeSlots.Length; i++)
        {
            storeSlots[i].Clear();
        }
    }

    void Buy()
    {
        if (!selectedConsumable) return;
        if(selectedConsumable.consumablePrice <= store.GetInventory().GetCurrency())
        {
            store.GetInventory().ChangeCurrency(-selectedConsumable.consumablePrice);
            store.Remove(selectedConsumable);
            store.GetInventory().Add(selectedConsumable);
            chat.text = "Thank you for your purchase. Hope to see you again.";
        }
        else
        {
            chat.text = "Sorry, it seems you don't have enough money. Feel free to come back when you do.";
        }
        selectedConsumable = null;
    }

    public void OnClickSlot(string details, string price, ConsumableSO selectedConsumable = null)
    {
        this.details.text = details;
        this.price.text = price;
        this.selectedConsumable = selectedConsumable;
    }
}