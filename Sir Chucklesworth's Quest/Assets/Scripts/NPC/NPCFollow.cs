using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private bool isFollowing = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isFollowing = true; // Start following when player is in range
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isFollowing = false; // Stop following when player exits range
        }
    }

    private void Update()
    {
        if (isFollowing && PlayerMovement.canFollow)
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
