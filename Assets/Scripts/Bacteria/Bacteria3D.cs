using UnityEngine;

public class Bacteria3D : MonoBehaviour
{
    [SerializeField]
    private float range;
    [SerializeField]
    private Transform player;
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
        player = FindObjectOfType<Player>().transform;
        soundManager = FindObjectOfType<SoundManager>();
    }

    void Update()
    {
        if (player == null) return;

        //Diff Method
        if (DistToPlayer() < range)
        {
            transform.LookAt(new Vector3(player.position.x, player.position.y + 2, player.position.z));
            Vector3 direction = (new Vector3(player.position.x,player.position.y + 2, player.position.z) - transform.position).normalized;
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
        distToPlayer = Vector3.Distance(transform.position, player.position);
        return distToPlayer;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.HitSound);
            Player player = other.GetComponent<Player>();
            player.DOTDam = damage;
            player.DoDOT = true;
            Destroy(gameObject);
        }
    }
}