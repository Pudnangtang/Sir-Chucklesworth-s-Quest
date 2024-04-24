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
        npcFollow = FindObjectOfType<NPCFollow>(); // Cache the NPC's follow script
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (npcFollow != null)
            {
                npcFollow.following = !npcFollow.following; // Toggle the NPC's following state

                // Update visualCue based on whether the NPC is now following or not
                visualCue.SetActive(npcFollow.following);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            // Only activate the visual cue if the NPC is not currently following
            if (npcFollow != null && !npcFollow.following)
            {
                visualCue.SetActive(true);
            }
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
