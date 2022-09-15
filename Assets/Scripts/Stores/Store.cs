using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private ConsumableStorageSO storeStorage;
    [SerializeField] private ConsumableSO[] consumables;
    [SerializeField] private GameObject storeUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private Button openStoreButton;
    private Inventory inventory;
    private float refreshTime;

    public delegate void StoreChanged();
    public StoreChanged storeChanged;

    void Update()
    {
        if(refreshTime > 0)
        {
            refreshTime -= Time.deltaTime;
        }
        else
        {
            RefreshStore();
            refreshTime = 30;
        }
    }

    public void Add(ConsumableSO consumable)
    {
        storeStorage.consumableSOs.Add(consumable);
        storeChanged?.Invoke();
    }

    public void Remove(ConsumableSO consumable)
    {
        storeStorage.consumableSOs.Remove(consumable);
        storeChanged?.Invoke();
    }

    public ConsumableStorageSO GetStoreStorage()
    {
        return storeStorage;
    }

    public Inventory GetInventory()
    {
        if (!inventory) return null; 
        return inventory;
    }

    void Awake()
    {
        openStoreButton.onClick.AddListener(OpenStore);
    }

    void OpenStore()
    {
        if (!storeUI.activeInHierarchy)
        {
            storeUI.SetActive(true);
            inventoryUI.SetActive(true);
        }
        else
        {
            storeUI.SetActive(false);
            inventoryUI.SetActive(false);
        }
    }

    void RefreshStore()
    {
        if(storeStorage.consumableSOs.Count < 6)
        {
            int index = Random.Range(0,consumables.Length-1);
            Add(consumables[index]);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Inventory inventory = other.GetComponent<Inventory>();
            this.inventory = inventory;
            openStoreButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            inventory = null;
            openStoreButton.gameObject.SetActive(false);
            storeUI.SetActive(false);
            inventoryUI.SetActive(false);
        }
    }
}