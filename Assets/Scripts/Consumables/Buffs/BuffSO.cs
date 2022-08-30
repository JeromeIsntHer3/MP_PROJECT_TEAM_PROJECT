using UnityEngine;

public class BuffSO : ConsumableSO
{
    public float duration;

    public override void ConsumableFunction(GameObject parent)
    {
        BuffHandler buffHandler = parent.GetComponent<BuffHandler>();
        Debug.Log(buffHandler);
        buffHandler.AddNewBuff(this);
    }

    public virtual void StartEffect(GameObject parent) { }
    public virtual void EndEffect(GameObject parent) { }
}