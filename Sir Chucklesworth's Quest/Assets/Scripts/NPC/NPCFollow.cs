using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public float followDistance = 1.5f;  // Distance behind the player
    public bool isFollowing = false;  // Make public if needed or manage internally

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
        // follow behind the player
    }

}
