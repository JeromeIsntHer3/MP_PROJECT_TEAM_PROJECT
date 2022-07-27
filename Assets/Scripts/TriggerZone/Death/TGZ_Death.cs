using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggerZone", menuName = "TriggerZoneData/Death")]
public class TGZ_Death : TriggerZoneData
{
    public override void TriggerZoneFunction()
    {
        base.TriggerZoneFunction();
        Debug.Log("Trigger Zone: Death Has Been Triggered");
        Player player = FindObjectOfType<Player>();
        if (player)
        {
            Destroy(player.gameObject);
            SoundManager.Instance.PlaySound(SoundManager.Instance.DieSound);
            TriggerZone.GameOver = true;
        }
    }
}