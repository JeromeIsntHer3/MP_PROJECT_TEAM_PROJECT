using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Additional Jump",menuName = "Buff/Jumps")]
public class AdditionalJumps : Buff
{
    public int jumps;

    public override void Effect(GameObject parent)
    {
        PlayerMovement3D pm = parent.GetComponent<PlayerMovement3D>();
        pm.NoOfJumpsAllowed = jumps;
    }

    public override void EffectOver(GameObject parent)
    {
        PlayerMovement3D pm = parent.GetComponent<PlayerMovement3D>();
        pm.NoOfJumpsAllowed = 1;
    }
}