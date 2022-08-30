using UnityEngine;

[CreateAssetMenu(fileName = "Buff_Jump",menuName = "Buff/Jump Buff")]
public class Buff_JumpSO : BuffSO
{
    public int NoOfJumps;
    public override void StartEffect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.NoOfJumpsAllowed = NoOfJumps;
    }

    public override void EndEffect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.NoOfJumpsAllowed = 1;
    }
}