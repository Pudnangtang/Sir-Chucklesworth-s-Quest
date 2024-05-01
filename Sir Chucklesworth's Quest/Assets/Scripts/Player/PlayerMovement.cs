using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float dashSpeed = 20.0f;
    public float dashTime = 0.1f;
    private Rigidbody2D rb;
    public Vector2 moveDirection;
    private float dashTimeLeft;
    private bool isDashing;
    public static bool canFollow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canFollow = false;  //start
    }

    void Update()
    {
        ProcessInputs();
        if (Input.GetKeyDown(KeyCode.F))
        {
            canFollow = !canFollow;
        }
    }

    void FixedUpdate()
    {
        Move();
        if (moveDirection.x != 0)
        {
            FlipCharacter(moveDirection.x);
        }
    }

    private void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isDashing)
        {
            isDashing = true;
            dashTimeLeft = dashTime;
        }
    }

    private void Move()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {
                rb.velocity = moveDirection * dashSpeed;
                dashTimeLeft -= Time.fixedDeltaTime;
            }
            else
            {
                isDashing = false;
                rb.velocity = Vector2.zero; // Reset velocity after dashing
            }
        }
        else
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
       //flip player
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
