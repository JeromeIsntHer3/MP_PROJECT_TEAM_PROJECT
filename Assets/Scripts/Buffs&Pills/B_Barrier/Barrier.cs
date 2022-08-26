using UnityEngine;

[CreateAssetMenu(fileName = "Barrier", menuName = "BuffScriptableObject/Barrier")]
public class Barrier : BuffScriptableObject
{
    public override void Effect(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        //player.EnableBarrier();
    }

    public override void EffectOver(GameObject parent)
    {
        Player player = parent.GetComponent<Player>();
        //player.DisableBarrier();
    }
}