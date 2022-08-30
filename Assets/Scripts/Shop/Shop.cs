using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject shopGO;
    [SerializeField] private ConsumableSO selectedSlotConsumableSO;
    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI priceText;

    [Header("Instantiating")]
    [SerializeField] private Transform shopContent;
    [SerializeField] private Transform inventoryContent;
    [SerializeField] private GameObject shopSlotPrefab;

    [Header("Storages")]
    [SerializeField] private ConsumableStorageSO shopStorage;
    public ConsumableStorageSO inventoryStorage;

    private bool nearShop;

    void OnEnable()
    {
        UpdateSlots();
        buyButton.onClick.AddListener(Buy);
    }

    void OnDisable()
    {
        buyButton.onClick.RemoveListener(Buy);
    }

    void Update()
    {
        if (nearShop)
        {
            player.SetInteractBox(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                shopGO.SetActive(true);
            }
        }
        else
        {
            player.SetInteractBox(false);
            shopGO.SetActive(false);
        }
    }

    void UpdateSlots()
    {
        ClearSlots();
        SetUpSlots();
    }

    void SetUpSlots()
    {
        if (shopContent)
        {
            for (int i = 0; i < shopStorage.consumableScriptableObjects.Count; i++)
            {
                GameObject tempSlot = Instantiate(shopSlotPrefab, shopContent.transform.position, Quaternion.identity);
                tempSlot.transform.SetParent(shopContent);
                ShopSlot slot = tempSlot.GetComponent<ShopSlot>();
                {
                    slot.SetShopSlot(shopStorage.consumableScriptableObjects[i], this);
                }
            }
        }
        if (inventoryContent)
        {
            for (int i = 0; i < inventoryStorage.consumableScriptableObjects.Count; i++)
            {
                GameObject tempSlot = Instantiate(shopSlotPrefab, inventoryContent.transform.position, Quaternion.identity);
                tempSlot.transform.SetParent(inventoryContent);
                ShopSlot slot = tempSlot.GetComponent<ShopSlot>();
                {
                    slot.SetShopSlot(inventoryStorage.consumableScriptableObjects[i], this);
                }
            }
        }
    }

    void ClearSlots()
    {
        if (shopContent)
        {
            for (int i = 0; i < shopContent.childCount; i++)
            {
                Destroy(shopContent.GetChild(i).gameObject);
            }
        }
        if (inventoryContent)
        {
            for (int i = 0; i < inventoryContent.childCount; i++)
            {
                Destroy(inventoryContent.GetChild(i).gameObject);
            }
        }
        descriptionText.text = "";
        priceText.text = "";
    }

    void Buy()
    {

    }

    public void SetSelectedSlotShopInfo(string currentDescription, int price, ConsumableSO currentConsumable)
    {
        descriptionText.text = "Details: \n" + currentDescription;
        priceText.text = "Price: " + price.ToString();
        selectedSlotConsumableSO = currentConsumable;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            nearShop = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            nearShop = false;
        }
    }
}