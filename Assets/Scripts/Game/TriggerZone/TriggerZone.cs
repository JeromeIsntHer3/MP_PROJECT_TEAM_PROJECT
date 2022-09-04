using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    public enum TriggerType { Die, Respawn }

    public TriggerType triggerType;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>())
        {
            Player player = other.GetComponent<Player>();
            switch (triggerType)
            {
                case TriggerType.Die:
                    player.Respawn();
                    break;

                case TriggerType.Respawn:
                    player.SetRespawnLocation(transform.position);
                    break;

                default:
                    return;
            }
        }
    }
}