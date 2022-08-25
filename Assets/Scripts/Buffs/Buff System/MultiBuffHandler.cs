using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiBuffHandler : MonoBehaviour
{
    private BuffScriptableObject collectedBuff;
    private DisplayBuffHandler displayBuffHandler;
    private SoundManager sm;

    [HideInInspector]
    public List<int> ids;
    [HideInInspector]
    public List<BuffScriptableObject> activeBuffs;
    [HideInInspector]
    public List<float> durationTimes;

    void Awake()
    {
        displayBuffHandler = FindObjectOfType<DisplayBuffHandler>();
        sm = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        DecrementDuration();
    }

    private void DecrementDuration()
    {
        for (int i = durationTimes.Count - 1; i >= 0; i--)
        {
            if (durationTimes[i] > 0) durationTimes[i] -= Time.deltaTime;
            if (durationTimes[i] <= 0)
            {
                ids.RemoveAt(i);
                durationTimes.RemoveAt(i);
                activeBuffs[i].EffectOver(gameObject);
                activeBuffs.RemoveAt(i);
            }
        }
        foreach (BuffScriptableObject buff in activeBuffs)
        {
            if (!buff) return;
            buff.Effect(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BuffHolder>())
        {
            sm.PlaySound(sm.pickUpSound);

            collectedBuff = other.GetComponent<BuffHolder>().thisBuff;

            if (ids.Contains(collectedBuff.id))
            {
                int index = ids.IndexOf(collectedBuff.id);
                durationTimes[index] += collectedBuff.buffDuration;

                if (!displayBuffHandler) return;
                displayBuffHandler.ExistingBuffPickedUp(collectedBuff.name,collectedBuff.buffDuration);
            }
            else
            {
                ids.Add(collectedBuff.id);
                activeBuffs.Add(collectedBuff);
                durationTimes.Add(collectedBuff.buffDuration);

                if (!displayBuffHandler) return;
                displayBuffHandler.NewBuffPickedUp(durationTimes.IndexOf(collectedBuff.buffDuration),
                    collectedBuff.name,collectedBuff.buffSprite);

                collectedBuff = null;
            }
            Destroy(other.gameObject);
        }
    }
}