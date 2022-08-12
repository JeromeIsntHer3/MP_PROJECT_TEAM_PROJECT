using UnityEngine;

[CreateAssetMenu(fileName = "TriggerZone", menuName = "TriggerZoneData/Heal")]
public class TGZ_Heal : TriggerZoneData
{
    public float healAmount;

    public override void TriggerZoneFunction()
    {
        base.TriggerZoneFunction();
        Player player = FindObjectOfType<Player>();
        player.Heal(healAmount);
    }
}