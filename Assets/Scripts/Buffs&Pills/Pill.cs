using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField] private float healAmount;
    [SerializeField] private float recoveryAmount;
    [SerializeField] private float infectionRateAmountDecrease;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            player.StopAllCoroutines();
            float currTime = TimeHandler.instance.TimeCountDown;

            switch (currTime)
            {
                case < 5:
                    player.ChangeStat(TypeOfStat.Recovery, recoveryAmount);
                    player.ChangeStat(TypeOfStat.Health, healAmount);
                    break;
                case < 15:
                    player.ChangeStat(TypeOfStat.Recovery, recoveryAmount);
                    player.ChangeStat(TypeOfStat.Health, healAmount / 2);
                    break;
                default:
                    player.ChangeStat(TypeOfStat.Recovery, recoveryAmount / 2);
                    player.ChangeStat(TypeOfStat.Health, -healAmount);
                    break;
            }
            player.ChangeStat(TypeOfStat.Infection, -infectionRateAmountDecrease);
            Destroy(gameObject);
        }
    }
}
