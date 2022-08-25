using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Additional Jump",menuName = "BuffScriptableObject/Jumps")]
public class AdditionalJumps : BuffScriptableObject
{
    public int jumps;

    public override void Effect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.NoOfJumpsAllowed = jumps;
    }

    public override void EffectOver(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.NoOfJumpsAllowed = 1;
    }
}