using UnityEngine;

public class Bacteria : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    private float distToPlayer;
    private Rigidbody rb;
    private Vector2 moveDir;

    private SoundManager soundManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = FindObjectOfType<Player>().transform;
        soundManager = SoundManager.instance;
    }

    void Update()
    {
        if (playerTransform == null) return;

        //Diff Method
        if (DistToPlayer() < range)
        {
            transform.LookAt(new Vector3(playerTransform.position.x, playerTransform.position.y + 2, playerTransform.position.z));
            Vector3 direction = (new Vector3(playerTransform.position.x,playerTransform.position.y + 2, playerTransform.position.z) - transform.position).normalized;
            moveDir = direction;
            rb.velocity = new Vector2(moveDir.x, moveDir.y) * speed;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
    }

    float DistToPlayer()
    {
        distToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        return distToPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.ChangeStat(TypeOfStat.Health, 2);
            Destroy(gameObject);
        }
    }
}