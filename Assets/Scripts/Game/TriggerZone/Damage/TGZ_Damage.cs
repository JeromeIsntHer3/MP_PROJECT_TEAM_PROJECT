using UnityEngine;

[CreateAssetMenu(fileName = "TriggerZone", menuName = "TriggerZoneData/Damage")]
public class TGZ_Damage : TriggerZoneData
{
    public float damageAmount;

    public override void TriggerZoneFunction()
    {
        base.TriggerZoneFunction();
        Player player = FindObjectOfType<Player>();
        player.Damage(damageAmount);
    }
}