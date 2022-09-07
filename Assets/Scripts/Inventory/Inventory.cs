using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ConsumableStorageSO inventoryConsumableStorage;
    [SerializeField] private int currency;
    [SerializeField] private TextMeshProUGUI coins;

    public delegate void InventoryChanged();
    public InventoryChanged inventoryChanged;

    public void Add(ConsumableSO consumable)
    {
        inventoryConsumableStorage.AddConsumable(consumable);
        inventoryChanged?.Invoke();
    }

    public void Remove(ConsumableSO consumable)
    {
        inventoryConsumableStorage.RemoveConsumable(consumable);
        inventoryChanged?.Invoke();
    }

    public ConsumableStorageSO GetInventoryStorage()
    {
        return inventoryConsumableStorage;
    }

    public void ChangeCurrency(int amount)
    {
        currency += amount;
        GameHandler.instance.CurrencyIncrease(amount);
        coins.text = currency.ToString();
    }

    public int GetCurrency()
    {
        return currency;
    }
}