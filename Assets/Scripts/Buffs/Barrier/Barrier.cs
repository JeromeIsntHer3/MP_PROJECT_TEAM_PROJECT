using UnityEngine;

[CreateAssetMenu(fileName = "Barrier", menuName = "Buff/Barrier")]
public class Barrier : Buff
{
    public override void Effect(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        player.EnableBarrier();
    }

    public override void EffectOver(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        player.DisableBarrier();
    }
}