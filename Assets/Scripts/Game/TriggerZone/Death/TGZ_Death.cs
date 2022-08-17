using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggerZone", menuName = "TriggerZoneData/Death")]
public class TGZ_Death : TriggerZoneData
{
    public override void TriggerZoneFunction()
    {
        base.TriggerZoneFunction();
        SoundManager sm = FindObjectOfType<SoundManager>();
        sm.PlaySound(sm.DieSound);
        Debug.Log("Trigger Zone: Death Has Been Triggered");
        Player player = FindObjectOfType<Player>();
        if (player)
        {
            Destroy(player.gameObject);
            TriggerZone.GameOver = true;
        }
    }
}