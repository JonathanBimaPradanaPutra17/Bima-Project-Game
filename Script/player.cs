using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool facingRight = true; // Untuk membalik arah karakter

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Mendeteksi Input Jalan (A/D atau Panah)
        moveInput = Input.GetAxisRaw("Horizontal");

        // Logika untuk membalik arah (Flip)
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        // Mendeteksi Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        // Mendeteksi Input Lompat (Space)
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Di Unity 6, gunakan linearVelocity untuk performa lebih baik
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        // Menjalankan Karakter
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}