using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Player))]

public class PlayerMovement : MonoBehaviour
{
    //Component Variables
    [HideInInspector]
    public Rigidbody rb;
    [HideInInspector]
    public PlayerInput playerInput;
    private GroundCheck groundCheck;

    [Header("Movement Attributes")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lerpAmount = 1f;

    [Header("Jump Attributes")]
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float baseGravScale;
    [SerializeField]
    private float increasedGravScale;
    [SerializeField]
    private float apexBoost;
    [SerializeField]
    private float jumpFallOffAtApex;
    [SerializeField]
    private float coyotoTimeBuffer;
    [SerializeField]
    private float extraHeight;
    private int noOfJumpsAllowed;
    private int noOfJumps;
    private float? lastGroundedTime;

    private bool _isFacingRight;
    private SoundManager soundManager;

    public float IncreasedGravity { get { return increasedGravScale; } set { increasedGravScale = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public int NoOfJumpsAllowed { get { return noOfJumpsAllowed; } set { noOfJumpsAllowed = value; } }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    private void Start()
    {
        soundManager = SoundManager.instance;
    }

    void Move()
    {
        float topSpeedX = speed * playerInput.movementInput.x;
        topSpeedX = Mathf.Lerp(rb.velocity.x, topSpeedX, lerpAmount);
        rb.velocity = new Vector2(topSpeedX, rb.velocity.y);
        rb.AddForce(transform.right * topSpeedX);
    }

    void CheckFaceDir(bool isMovingRight)
    {
        if (isMovingRight != _isFacingRight)
        {
            Turn();
        }
    }

    void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        _isFacingRight = !_isFacingRight;
    }

    void Gravity()
    {
        if (rb.velocity.y < 0)
        {
            Physics.gravity = new Vector3(rb.velocity.x, increasedGravScale, rb.velocity.z);
        }
        else
        {
            Physics.gravity = new Vector3(rb.velocity.x, baseGravScale, rb.velocity.z);
        }
    }

    void Jump()
    {
        if (groundCheck.isGrounded)
        {
            lastGroundedTime = Time.time;
            noOfJumps = noOfJumpsAllowed;
        }
        if (playerInput.jumpPressed)
        {
            if (CoyoteJumpPossible())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce,rb.velocity.z);
                soundManager.PlaySound(soundManager.JumpSound);
            }
            else if (noOfJumps > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce,rb.velocity.z);
                soundManager.PlaySound(soundManager.JumpSound);
            }
        }
        if (playerInput.jumpReleased)
        {
            noOfJumps -= 1;
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / jumpFallOffAtApex);
            }
        }
    }

    void ApexBoost()
    {
        if (-10 < rb.velocity.y && rb.velocity.y <= -0.01)
        {
            if (playerInput.movementInput.x > 0)
            {
                rb.AddForce(transform.right * apexBoost);
            }
            else if (playerInput.movementInput.x < 0)
            {
                rb.AddForce(-transform.right * apexBoost);
            }
        }
    }

    bool CoyoteJumpPossible()
    {
        return Time.time - lastGroundedTime <= coyotoTimeBuffer;
    }

    void Update()
    {
        ApexBoost();
        Jump();
        Gravity();
    }

    void FixedUpdate()
    {
        Move();
        if (playerInput.movementInput.x != 0)
        {
            CheckFaceDir(playerInput.movementInput.x < 0);
        }
    }
}