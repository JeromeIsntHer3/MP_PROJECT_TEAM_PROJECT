using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff_Float", menuName = "Buff/Float Buff")]
public class Buff_FloatSO : BuffSO
{
    public float Gravity;
    public override void StartEffect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.IncreasedGravity = Gravity;
    }

    public override void EndEffect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.IncreasedGravity = -52;
    }
}