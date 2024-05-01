using UnityEngine;

public class NPCFollowTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange = false;
    private NPCFollow npcFollow;

    private void Awake()
    {
        visualCue.SetActive(false);
        npcFollow = FindObjectOfType<NPCFollow>(); 
    }

    private void Update()
    {
        // Check if the player is in range and F key is pressed
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (npcFollow != null)
            {
                npcFollow.ToggleFollowing(); 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            // Only activate the visual cue if the NPC is not 
            visualCue.SetActive(!npcFollow.following);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            visualCue.SetActive(false); 
        }
    }
}
