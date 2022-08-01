using UnityEngine;

public class Pill : MonoBehaviour
{
    [SerializeField]
    private float thisHealAmount;
    [SerializeField]
    private float thisProgressAmount;
    [SerializeField]
    private float thisProgressCap;
    [SerializeField]
    private GameObject[] pills; 

    private Player player;

    void Awake()
    {
        int index = Random.Range(0, pills.Length);
        Instantiate(pills[index], this.transform);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player = other.GetComponent<Player>();
            player.EnableBarrier();
            player.DoDOT = false;
            float currTime = player.timeHandler.TimeCountDown;
            if (5 > currTime && currTime > 0)
            {
                player.ProgressIncrease(thisProgressAmount, thisProgressCap);
                player.Heal(thisHealAmount);
            }
            else if (15 > currTime && currTime > 5)
            {
                player.ProgressIncrease(thisProgressAmount/2, thisProgressCap);
                player.Heal(thisHealAmount/2);
            }
            else
            {
                player.Damage(10);
            }
            Destroy(gameObject);
        }
    }
}