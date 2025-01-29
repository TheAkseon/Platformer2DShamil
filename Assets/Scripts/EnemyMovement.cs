using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 1.0f;
    private Rigidbody2D _rigidbody2D;
    private Transform _groundCheck;
    private Transform _wallCheck;
    private Transform _playerCheck;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _groundCheck = new GameObject("GroundCheck").transform;
        _groundCheck.parent = transform;
        _groundCheck.localPosition = new Vector3(0.5f * Mathf.Sign(_moveSpeed), -0.6f, 0);

        _wallCheck = new GameObject("WallCheck").transform;
        _wallCheck.parent = transform;
        _wallCheck.localPosition = new Vector3(0.5f * Mathf.Sign(_moveSpeed), 0, 0);
    }

    private void FixedUpdate()
    {
        Move();
        CheckGroundAhead();
        CheckWallAhead();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(_moveSpeed, _rigidbody2D.velocity.y);
    }

    private void CheckGroundAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(_groundCheck.position, Vector2.down, 0.2f);
        if (hit.collider == null)
        {
            Flip();
        }
    }

    private void CheckWallAhead()
    {
        RaycastHit2D hit = Physics2D.Raycast(_wallCheck.position, Vector2.right * Mathf.Sign(_moveSpeed), 0.2f);
        if (hit.collider != null && hit.collider.TryGetComponent(out Player player) == false)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _moveSpeed *= -1;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
