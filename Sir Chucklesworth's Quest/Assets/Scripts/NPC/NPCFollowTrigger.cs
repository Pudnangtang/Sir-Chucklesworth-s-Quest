using UnityEngine;

public class NPCFollowTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    private bool playerInRange = false;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            // Check if visualCue has been assigned before trying to set it active or inactive
            if (visualCue != null)
            {
                visualCue.SetActive(true);
            }
            else
            {
                Debug.LogError("Visual Cue GameObject is not assigned in the Inspector");
            }

            if (Input.GetKeyDown(KeyCode.F))
            {
                // Check if the NPCFollow component exists before trying to access it
                NPCFollow npcFollow = GetComponent<NPCFollow>();
                if (npcFollow != null)
                {
                    npcFollow.isFollowing = !npcFollow.isFollowing;
                }
                else
                {
                    Debug.LogError("NPCFollow component not found on the GameObject");
                }
            }
        }
        else
        {
            if (visualCue != null)
            {
                visualCue.SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            if (GetComponent<NPCFollow>() != null)
            { // Check if the NPCFollow component is not null
                GetComponent<NPCFollow>().isFollowing = false;  // Stop following when player exits range
            }
        }
    }

}
