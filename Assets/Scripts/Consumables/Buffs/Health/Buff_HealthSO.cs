using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff_Health", menuName = "Buff/Health Buff")]
public class Buff_HealthSO : BuffSO
{
    public float Health;
    public override void StartEffect(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        player.ChangeStat(TypeOfStat.Health,Random.Range(1,Health));
    }
}