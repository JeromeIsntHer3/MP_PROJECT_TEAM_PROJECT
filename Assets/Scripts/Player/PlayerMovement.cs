using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Player))]

public class PlayerMovement : MonoBehaviour
{
    //Component Variables
    private Rigidbody rb;
    private PlayerInput playerInput;
    private GroundCheck groundCheck;
    private Animator anim;

    [Header("Movement Attributes")]
    [SerializeField] private float speed;
    [SerializeField] private float acceleration = 1f;

    [Header("Jump Attributes")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float baseGravScale;
    [SerializeField] private float increasedGravScale;
    [SerializeField] private float apexBoost;
    [SerializeField] private float fallOffAtApex;
    [SerializeField] private float coyotoTimeBuffer;

    //Animation
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Land = Animator.StringToHash("Land");
    private static readonly int Air = Animator.StringToHash("In-Air");
    private static readonly int Jump = Animator.StringToHash("Jump");
    int currAnimState;
    float currAnimLock;
    bool landed;

    private int numberOfJumpsAvailable;
    private int numberOfJumps;
    private float? lastGroundedTime;

    private bool _isFacingRight;

    public float IncreasedGravity { get { return increasedGravScale; } set { increasedGravScale = value; } }
    public float Speed { get { return speed; } set { speed = value; } }
    public int NoOfJumpsAllowed { get { return numberOfJumpsAvailable; } set { numberOfJumpsAvailable = value; } }


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        anim = GetComponentInChildren<Animator>();
    }

    void Move()
    {
        float topSpeedX = speed * playerInput.movementInput.x;
        topSpeedX = Mathf.Lerp(rb.velocity.x, topSpeedX, acceleration);
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

    void PlayerJump()
    {
        if (Grounded())
        {
            landed = true;
            lastGroundedTime = Time.time;
            numberOfJumps = numberOfJumpsAvailable;
            landed = false;
        }
        if (playerInput.jumpPressed)
        {
            if (CoyoteJumpPossible())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce,rb.velocity.z);
            }
            else if (numberOfJumps > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce,rb.velocity.z);
            }
        }
        if (playerInput.jumpReleased)
        {
            numberOfJumps -= 1;
            if (rb.velocity.y > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y / fallOffAtApex);
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

    bool Grounded()
    {
        return groundCheck.isGrounded;
    }

    void Animate()
    {
        int state = GetAnimState();

        if (state == currAnimState) return;
        anim.CrossFade(state, 0.4f, 0);
        currAnimState = state;
    }

    int GetAnimState()
    {
        if (Time.time < currAnimLock) return currAnimState;

        if (landed) return LockState(Land, 0.2f);
        if (Grounded()) return playerInput.movementInput.x == 0 ? Idle : Walk;
        return rb.velocity.y > 0 ? Jump : Air;

        int LockState(int s, float t)
        {
            currAnimLock = Time.time + t;
            return s;
        }
    }

    void Update()
    {
        ApexBoost();
        PlayerJump();
        Gravity();
        Animate();
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