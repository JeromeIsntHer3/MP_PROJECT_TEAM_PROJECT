using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Consumeable", menuName = "Consumable/Storage")]
public class ConsumableStorageSO : ScriptableObject
{
    public List<ConsumableSO> consumableSOs;

    public void AddConsumable(ConsumableSO consumable)
    {
        consumableSOs.Add(consumable);
    }

    public void RemoveConsumable(ConsumableSO consumable)
    {
        consumableSOs.Remove(consumable);
    }
}