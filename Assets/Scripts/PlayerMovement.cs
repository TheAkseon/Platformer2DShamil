using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float jumpForce;
    public float moveSpeed;
    public float gravityForce;

    private Rigidbody2D rigidbody2D;
    private float minMoveSpeed = 0.1f;
    private float flipAngle = 180f;
    private bool isGrounded = false;
    private bool isFacingRight = false;
    private bool isJumpKeyPressed = false;

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.gravityScale = 1.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpKeyPressed = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        AddGravityForce();
        Move(horizontalInput);
        CheckMoveDirection(horizontalInput);

        if (isJumpKeyPressed)
        {
            Jump(horizontalInput);
            isJumpKeyPressed = false;
        }
    }

    private void AddGravityForce()
    {
        rigidbody2D.AddForce(Vector2.down * gravityForce);
    }

    private void Move(float horizontalInput)
    {
        rigidbody2D.velocity = new Vector2(horizontalInput * moveSpeed, rigidbody2D.velocity.y);
    }

    private void Jump(float horizontalInput)
    {
        if (isGrounded)
        {
            if (Mathf.Abs(rigidbody2D.velocity.x) < minMoveSpeed)
            {
                rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, jumpForce), ForceMode2D.Impulse);
            }
            else if (Mathf.Sign(rigidbody2D.velocity.x) == Mathf.Sign(horizontalInput))
            {
                rigidbody2D.AddForce(new Vector2(rigidbody2D.velocity.x, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    private void CheckMoveDirection(float horizontalInput)
    {
        if (horizontalInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (horizontalInput < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0, flipAngle, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Ground ground))
        {
            isGrounded = false;
        }
    }
}
