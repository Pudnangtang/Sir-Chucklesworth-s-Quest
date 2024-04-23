using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public float followDistance = 1.5f;  // Distance behind the player
    public bool isFollowing = false;  // Make public if needed or manage internally
    private Vector2 lastPlayerPosition;
    private Vector2 followDirection;

    private void Update()
    {
        // Update follow direction based on player movement
        if (player.position != (Vector3)lastPlayerPosition)
        {
            followDirection = (lastPlayerPosition - (Vector2)player.position).normalized;
            lastPlayerPosition = player.position;
        }

        if (isFollowing && PlayerMovement.canFollow)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        if (player != null)
        {
            // Calculate follow position based on the last movement direction
            Vector3 followPosition = (Vector2)player.position + followDirection * followDistance;
            transform.position = Vector2.MoveTowards(transform.position, followPosition, speed * Time.deltaTime);
        }
    }
}
