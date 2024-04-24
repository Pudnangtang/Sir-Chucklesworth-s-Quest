using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public float followDistance = 1.5f;
    private Vector2 followDirection;
    private Rigidbody2D rb;
    public bool following = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        following = false;
    }

    void FixedUpdate()
    {
        // FixedUpdate is used for Rigidbody and other physics updates
        if (following) // Check if the NPC should follow the player
        {
            FollowPlayer();
        }
    }

    void Update()
    {
        // Update is used for non-physics updates like calculating direction
        if (player.position != (Vector3)rb.position)
        {
            followDirection = ((Vector2)player.position - rb.position).normalized;
        }
    }

    private void FollowPlayer()
    {
        // Follow the player maintaining a certain distance
        Vector2 targetPosition = (Vector2)player.position - followDirection * followDistance;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
        Debug.Log("Following Player");
    }
}
