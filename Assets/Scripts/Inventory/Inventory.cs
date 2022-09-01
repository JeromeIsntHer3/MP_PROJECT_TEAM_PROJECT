using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ConsumableStorageSO inventoryConsumableStorage;
    [SerializeField] private int currency;

    public delegate void InventoryChanged();
    public InventoryChanged inventoryChanged;

    public void Add(ConsumableSO consumable)
    {
        inventoryConsumableStorage.consumableSOs.Add(consumable);
        inventoryChanged?.Invoke();
    }

    public void Remove(ConsumableSO consumable)
    {
        inventoryConsumableStorage.consumableSOs.Remove(consumable);
        inventoryChanged?.Invoke();
    }

    public void ChangeCurrency(int amount)
    {
        currency += amount;
    }

    public ConsumableStorageSO GetInventory()
    {
        return inventoryConsumableStorage;
    }

    public int GetCurrency()
    {
        return currency;
    }
}