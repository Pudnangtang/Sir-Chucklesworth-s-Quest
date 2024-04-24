using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage = 20; // Example damage value
    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("NPC").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // Check if the projectile has reached the target (This check is not perfect and may not work correctly in all cases, consider using triggers or collision detection)
        if ((Vector2)transform.position == target)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that was hit has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // If so, destroy the projectile
            DestroyProjectile();
        }
        // Keep the existing check for the NPC tag if you want to handle that collision as well
        else if (other.CompareTag("NPC"))
        {
            // Call TakeDamage on the NPC's health script
            NPCHealth npcHealth = other.GetComponent<NPCHealth>();
            if (npcHealth != null)
            {
                npcHealth.TakeDamage(damage);
            }
            // Destroy the projectile after hitting the NPC
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        // Destroy the projectile GameObject
        Destroy(gameObject);
    }
}
