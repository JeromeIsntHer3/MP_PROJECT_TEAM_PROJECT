using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableSO : ScriptableObject
{
    public Sprite consumableSprite;
    public Sprite inStoreSprite;
    [TextArea]
    public string consumableDescription;
    public int consumablePrice;

    public virtual void ConsumableFunction(GameObject parent) { }
}