using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private Transform inventoryParent;

    [Header("Buttons")]
    [SerializeField] private Button openInventory;
    [SerializeField] private Button clickToEat;
    [SerializeField] private Button clickToThrow;

    [Header("Slot Clicked Info")]
    [SerializeField] private TextMeshProUGUI currDetails;
    [SerializeField] private TextMeshProUGUI currPrice;
    [SerializeField] private ConsumableSO currConsumable;

    private InventorySlotUI[] inventorySlots;

    void OnEnable()
    {
        playerInventory.inventoryChanged += UpdateUI;

        openInventory?.onClick.AddListener(OpenUIInventory);
        clickToEat?.onClick.AddListener(OnClickEat);
        clickToThrow?.onClick.AddListener(OnClickThrow);

        inventorySlots = inventoryParent.GetComponentsInChildren<InventorySlotUI>();
        UpdateUI();
    }

    void OnDisable()
    {
        playerInventory.inventoryChanged -= UpdateUI;

        openInventory?.onClick.RemoveListener(OpenUIInventory);
        clickToEat?.onClick.RemoveListener(OnClickEat);
        clickToThrow?.onClick.RemoveListener(OnClickThrow);
    }

    void OpenUIInventory()
    {
        if (!inventoryUI.activeInHierarchy)
        {
            inventoryUI.SetActive(true);
        }
        else
        {
            inventoryUI.SetActive(false);
        }
    }

    void UpdateUI()
    {
        ClearSlots();
        SetupSlots();
        currDetails.text = "";
        currPrice.text = "Price: + \n";
    }

    void SetupSlots()
    {
        for (int i = 0; i < playerInventory.GetInventoryStorage().consumableSOs.Count; i++)
        {
            inventorySlots[i].SetSlot(playerInventory.GetInventoryStorage().consumableSOs[i],this);
        }
    }

    void ClearSlots()
    {
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].Clear();
        }
    }

    void OnClickEat()
    {
        if (currConsumable == null) return;
        currConsumable.ConsumableFunction(playerInventory.gameObject);
        playerInventory.Remove(currConsumable);
        currConsumable = null;
    }

    void OnClickThrow()
    {
        if (currConsumable == null) return;
        playerInventory.Remove(currConsumable);
        currConsumable = null;
    }

    public void OnClickSlot(string conDetails, ConsumableSO selectedConsumable)
    {
        currDetails.text = conDetails;
        currConsumable = selectedConsumable;
    }
}