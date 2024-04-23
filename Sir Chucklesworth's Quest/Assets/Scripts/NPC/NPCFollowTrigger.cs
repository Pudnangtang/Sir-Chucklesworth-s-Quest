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
                //call the npc follow script and start following the player
                NPCFollow.FollowPlayer();
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
        }
    }

}
