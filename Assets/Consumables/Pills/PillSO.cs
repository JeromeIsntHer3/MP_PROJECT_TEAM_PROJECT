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
        TimeHandler timeHandler = TimeHandler.instance;
        timeHandler.EatPill();
        switch (timeHandler.TimeStat())
        {
            case TimeStatus.Perfect:
                player.ChangeStat(TypeOfStat.Recovery, recoveryAmountToAdd);
                break;
            case TimeStatus.Early:
                player.ChangeStat(TypeOfStat.Recovery, recoveryAmountToAdd);
                player.ChangeStat(TypeOfStat.Health, -recoveryAmountToAdd / 2);
                break;
            case TimeStatus.TooEarly:
                player.ChangeStat(TypeOfStat.Recovery, recoveryAmountToAdd);
                player.ChangeStat(TypeOfStat.Health, -recoveryAmountToAdd);
                break;
        }
    }
}