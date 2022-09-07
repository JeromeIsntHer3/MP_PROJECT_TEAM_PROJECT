using UnityEngine;

[CreateAssetMenu(fileName = "Buff_Speed", menuName = "Buff/Speed Buff")]
public class Buff_SpeedSO : BuffSO
{
    public float speed;
    public override void StartEffect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.Speed = speed;
    }

    public override void EndEffect(GameObject parent)
    {
        PlayerMovement pm = parent.GetComponent<PlayerMovement>();
        pm.Speed = 10;
    }
}