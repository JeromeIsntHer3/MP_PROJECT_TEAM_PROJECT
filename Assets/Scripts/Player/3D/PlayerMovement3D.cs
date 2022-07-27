using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Player))]

public class PlayerMovement3D : MonoBehaviour
{
    //Component Variables
    private Rigidbody rb;
    private CapsuleCollider capsuleCol;
    private PlayerInput playerInput;

    [Header("Movement Attributes")]
    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }
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
    public int NoOfJumpsAllowed { get { return noOfJumpsAllowed; } set { noOfJumpsAllowed = value; } }
    private int noOfJumps;
    private float? lastGroundedTime;

    [Header("Ground Check")]
    public LayerMask groundLayerMask;

    private bool _isFacingRight;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCol = GetComponent<CapsuleCollider>();
        playerInput = GetComponent<PlayerInput>();
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

    bool IsGrounded()
    {
        bool raycastHit = Physics.BoxCast(capsuleCol.bounds.center,transform.localScale, Vector3.down,
            transform.rotation,extraHeight, groundLayerMask);
        return raycastHit;
    }

    void Jump()
    {
        if (IsGrounded())
        {
            Debug.Log("IS Grounded");
            lastGroundedTime = Time.time;
            noOfJumps = noOfJumpsAllowed;
        }
        if (playerInput.jumpPressed)
        {
            if (CoyoteJumpPossible())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce,rb.velocity.z);
                if (!SoundManager.Instance) return;
                SoundManager.Instance.PlaySound(SoundManager.Instance.JumpSound);
            }
            else if (noOfJumps > 0)
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpForce);
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
                rb.AddForce(transform.right * -apexBoost);
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