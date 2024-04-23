using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public float followDistance = 1.5f;
    private Vector2 lastPlayerPosition;
    private Vector2 followDirection;
    private Rigidbody2D rb;
    public bool following = false;
    private bool isFollowing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lastPlayerPosition = player.position;
        following = false;
    }

    private void Update()
    {
        if (player.position != (Vector3)lastPlayerPosition)
        {
            followDirection = (player.position - (Vector3)lastPlayerPosition).normalized;
            lastPlayerPosition = player.position;
        }

        if (following) // Use this flag to check if NPC should follow
        {
            FollowPlayer();
        }
    }

    public void InitializeFollow()
    {
        following = true; // Set the flag to start following
        FollowPlayer(); // Optionally, call FollowPlayer here if you want to move immediately
    }



    public void FollowPlayer()
    {
        Vector2 targetPosition = (Vector2)player.position - followDirection * followDistance;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.deltaTime);
        rb.MovePosition(newPosition);
        following = true;
        Debug.Log("Following Player");
    }
}
