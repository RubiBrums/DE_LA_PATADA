using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public int extraJumps = 1;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded = false;
    private int jumpsLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsLeft = extraJumps;
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            jumpsLeft = extraJumps;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpsLeft > 0))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput> 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Moverse a la derecha
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Moverse a la izquierda
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpsLeft--;
    }

    public void ForcedJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
}
