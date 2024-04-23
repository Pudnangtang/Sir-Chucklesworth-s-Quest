using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public float followDistance = 1.5f; // Distance behind the player
    private bool isFollowing = false;
    private Vector2 lastPlayerPosition;
    private Vector2 followDirection;


    private void Update()
    {
        if (isFollowing && PlayerMovement.canFollow)
        {
            FollowPlayer();
        }
        // Update the follow direction each frame
        if (player.position != (Vector3)lastPlayerPosition)
        {
            followDirection = (lastPlayerPosition - (Vector2)player.position).normalized;
            lastPlayerPosition = player.position;
        }
    }

    public void FollowPlayer()
    {
        if (player != null)
        {
            // Calculate the follow position based on the last movement direction
            Vector3 followPosition = (Vector2)player.position + followDirection * followDistance;
            transform.position = Vector2.MoveTowards(transform.position, followPosition, speed * Time.deltaTime);
        }
    }
}
