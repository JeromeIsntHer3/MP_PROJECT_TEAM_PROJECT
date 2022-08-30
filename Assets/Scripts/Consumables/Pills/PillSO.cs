using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Pill", menuName ="Pill/Pill")]
public class PillSO : ConsumableSO
{
    public float recoveryAmountToAdd;
    public override void ConsumableFunction(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        player.ChangeStat(TypeOfStat.Recovery,recoveryAmountToAdd);
    }
}