using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffHandler : MonoBehaviour
{
    [SerializeField] private List<BuffSO> activeBuffs;
    [SerializeField] private List<float> buffTimes;

    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform parentDisplay;

    void Update()
    {
        TickDownTimes();
    }

    void TickDownTimes()
    {
        for (int i = buffTimes.Count - 1; i >= 0; i--)
        {
            //If this time is greater than 0, decrease Time.
            if (buffTimes[i] > 0)
            {
                buffTimes[i] -= Time.deltaTime;
            }
            //If this time is lesser or equal to 0, remove the buff and time from their lists
            if (buffTimes[i] <= 0)
            {
                buffTimes.RemoveAt(i);
                RemoveEffect(activeBuffs[i]);
                activeBuffs.RemoveAt(i);
            }
        }
    }

    void ApplyEffect(BuffSO newBuff)
    {
        newBuff.StartEffect(gameObject);
    }

    void RemoveEffect(BuffSO removeBuff)
    {
        removeBuff.EndEffect(gameObject);
    }

    void DisplayBuff(BuffSO newBuff)
    {
        GameObject temp = Instantiate(slotPrefab, parentDisplay.position, Quaternion.identity);
        temp.transform.SetParent(parentDisplay);
        DisplayBuffSlot displayBuffSlot = temp.GetComponent<DisplayBuffSlot>();
        if (!displayBuffSlot) return;
        displayBuffSlot.SetUpDisplayBuffSlot(newBuff.name, newBuff.duration, newBuff.consumableSprite);
    }

    void AddExistingDisplayedBuffTime(BuffSO existingBuff)
    {
        GameObject temp = parentDisplay.transform.Find(existingBuff.name).gameObject;
        if (!temp) return;
        DisplayBuffSlot buffSlot = temp.GetComponent<DisplayBuffSlot>();
        if (!buffSlot) return;
        buffSlot.AddTime(existingBuff.duration);
    }

    public void AddNewBuff(BuffSO newBuff)
    {
        if (activeBuffs.Contains(newBuff))
        {
            int index = activeBuffs.IndexOf(newBuff);
            buffTimes[index] += newBuff.duration;
            AddExistingDisplayedBuffTime(newBuff);
        }
        else
        {
            activeBuffs.Add(newBuff);
            buffTimes.Add(newBuff.duration);
            ApplyEffect(newBuff);
            DisplayBuff(newBuff);
        }
    }
}