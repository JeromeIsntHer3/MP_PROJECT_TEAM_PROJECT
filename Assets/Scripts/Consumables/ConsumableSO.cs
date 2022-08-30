using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsumableSO : ScriptableObject
{
    public Sprite consumableSprite;
    [TextArea]
    public string consumableDescription;
    [TextArea]
    public string consumableStatus;
    public int consumablePrice;

    public virtual void ConsumableFunction(GameObject parent) { }
}