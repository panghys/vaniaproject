using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Player player;
    public groundDetection gd;
    public Rigidbody2D rb;

    [Header("Movimiento")]
    public float playerSpeed = 5f;
    private float horizontalMovement;

    [Header("Salto")]
    public float jumpPower = 5f;
    public float movingJump = 5f;
    public float standingJump = 0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player.isMoving = horizontalMovement != 0 && player.canMove;

        if (player.canMove)
        {
            if (horizontalMovement > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
            else if (horizontalMovement < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void FixedUpdate()
    {
        if (player.isGrounded)
        {
            if (player.canMove)
            {
                rb.linearVelocity = new Vector2(horizontalMovement * playerSpeed, rb.linearVelocityY);
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
            }
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && player.isGrounded && player.canMove)
        {
            float airHMov = player.isMoving ? Mathf.Sign(horizontalMovement) * movingJump : standingJump;

            rb.linearVelocity = new Vector2(airHMov, jumpPower);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!player.isAttacking) player.isAttacking = true;
        }
    }
}