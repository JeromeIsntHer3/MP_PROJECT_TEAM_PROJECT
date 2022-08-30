using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventory;
    [SerializeField] private ConsumableSO selectedSlotConsumableSO;
    [SerializeField] private Button consumeButton;
    [SerializeField] private Button throwButton;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private Transform parentDisplay;
    [SerializeField] private GameObject inventorySlotPrefab;

    public ConsumableStorageSO consumables;

    private bool active;

    void Awake()
    {
        inventory.transform.position = new Vector2(960, -465);
    }

    void OnEnable()
    {
        UpdateSlots();
        consumeButton.onClick.AddListener(OnClickEat);
        throwButton.onClick.AddListener(OnClickThrowAway);
    }

    void OnDisable()
    {
        ClearSlots();
        consumeButton.onClick.RemoveListener(OnClickEat);
        throwButton.onClick.RemoveListener(OnClickThrowAway);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!active)
            {
                LeanTween.move(inventory, new Vector2(960, 465), 0.5f).setEaseOutExpo();
                active = true;
            }
            else
            {
                LeanTween.move(inventory, new Vector2(960, -465), 0.5f).setEaseOutExpo();
                active = false;
            }
        }
    }

    void SetUpSlots()
    {
        if (parentDisplay)
        {
            for (int i = 0; i < consumables.consumableScriptableObjects.Count; i++)
            {
                GameObject tempSlot = Instantiate(inventorySlotPrefab, parentDisplay.transform.position, Quaternion.identity);
                tempSlot.transform.SetParent(parentDisplay);
                InventorySlot slot = tempSlot.GetComponent<InventorySlot>();
                {
                    slot.SetInventorySlot(consumables.consumableScriptableObjects[i],this);
                }
            }
        }
    }

    void ClearSlots()
    {
        descriptionText.text = "";
        statusText.text = "";
        if (parentDisplay)
        {
            for(int i = 0; i < parentDisplay.childCount; i++)
            {
                Destroy(parentDisplay.GetChild(i).gameObject);
            }
        }
    }

    void UpdateSlots()
    {
        ClearSlots();
        SetUpSlots();
    }

    void OnClickEat()
    {
        if (selectedSlotConsumableSO == null) return;

        selectedSlotConsumableSO.ConsumableFunction(player);
        consumables.consumableScriptableObjects.Remove(selectedSlotConsumableSO);
        selectedSlotConsumableSO = null;
        UpdateSlots();
    }

    void OnClickThrowAway()
    {
        if (selectedSlotConsumableSO == null) return;
        consumables.consumableScriptableObjects.Remove(selectedSlotConsumableSO);
        selectedSlotConsumableSO = null;
        UpdateSlots();
    }

    public void SetSelectedSlotInventoryInfo(string currentDescription, string currentStatus, ConsumableSO currentConsumable)
    {
        descriptionText.text = "Details: \n" + currentDescription;
        statusText.text = "Status: \n" + currentStatus;
        selectedSlotConsumableSO = currentConsumable; 
    }
}