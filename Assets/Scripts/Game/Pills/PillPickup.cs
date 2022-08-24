using UnityEngine;

public class PillPickup : MonoBehaviour
{
    [SerializeField]
    private float healAmount;
    [SerializeField]
    private float recoveryAmount;
    [SerializeField]
    private GameObject[] pillPrefabs; 

    private Player player;

    void Awake()
    {
        int index = Random.Range(0, pillPrefabs.Length);
        Instantiate(pillPrefabs[index], this.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.StopAllCoroutines();
            float currTime = TimeHandler.instance.TimeCountDown;
            if (5 > currTime && currTime > 0)
            {
                player.ChangeStat(TypeOfStat.Recovery, recoveryAmount);
                player.ChangeStat(TypeOfStat.Health,healAmount);
            }
            else if (15 > currTime && currTime > 5)
            {
                player.ChangeStat(TypeOfStat.Recovery, recoveryAmount);
                player.ChangeStat(TypeOfStat.Health, healAmount / 2);
            }
            else
            {
                player.ChangeStat(TypeOfStat.Recovery, recoveryAmount);
                player.ChangeStat(TypeOfStat.Health, -healAmount);
            }
            Destroy(gameObject);
        }
    }
}