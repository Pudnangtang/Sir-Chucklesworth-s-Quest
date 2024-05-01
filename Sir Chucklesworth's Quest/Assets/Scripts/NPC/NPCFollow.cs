using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public GameObject visualCue; // Reference to the visual cue GameObject
    public float followDistance = 1.5f;
    private Vector2 followDirection;
    private Rigidbody2D rb;
    public bool following = false;

    public AudioClip followSound; // Audio clip to play when following starts
    private AudioSource audioSource; // AudioSource component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        following = false;
    }

    void FixedUpdate()
    {
        // Follow the player if the following flag is true
        if (following && Vector3.Distance(transform.position, player.position) > followDistance)
        {
            FollowPlayer();
        }
        else if (!following)
        {
            StopFollowing();
        }
    }

    void Update()
    {
        if (player.position != (Vector3)rb.position)
        {
            followDirection = ((Vector2)player.position - rb.position).normalized;
        }
    }

    public void ToggleFollowing()
    {
        following = !following;
        if (following)
        {
            audioSource.PlayOneShot(followSound); // Play sound when starting to follow
            visualCue.SetActive(false);
        }
        else
        {
            visualCue.SetActive(true);
        }
    }

    private void FollowPlayer()
    {
        Vector2 targetPosition = (Vector2)player.position - followDirection * followDistance;
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    void StopFollowing()
    {

    }
}
