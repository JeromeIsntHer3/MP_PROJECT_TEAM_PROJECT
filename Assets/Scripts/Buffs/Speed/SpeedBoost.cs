using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Speed Boost", menuName = "Buff/Speed Boost")]
public class SpeedBoost : Buff
{
    public float newSpeed;

    public override void Effect(GameObject parent)
    {
        PlayerMovement3D pm = parent.GetComponent<PlayerMovement3D>();
        pm.Speed = newSpeed;
    }
    public override void EffectOver(GameObject parent)
    {
        PlayerMovement3D pm = parent.GetComponent<PlayerMovement3D>();
        pm.Speed = 20;
    }
}