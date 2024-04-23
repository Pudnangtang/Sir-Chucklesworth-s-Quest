using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float dashSpeed = 20.0f; 
    public float dashTime = 0.1f; 

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private float dashTimeLeft;
    private bool isDashing;

    public static bool canFollow;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            }
        }
        else
        {
            rb.velocity = moveDirection * moveSpeed;
        }
    }
}
