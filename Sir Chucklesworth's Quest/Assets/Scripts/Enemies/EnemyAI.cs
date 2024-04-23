using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public float attackRange = 1.0f;
    private Rigidbody2D rb;
    private Vector2 movement;
    //public Animator animator; // Assuming there is an Animator component

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Determine the direction to the player
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        // Check for attack range
        if (Vector3.Distance(player.position, transform.position) <= attackRange)
        {
            // Attack
            Attack();
        }
    }

    void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void Attack()
    {
        // Trigger attack animation
        //animator.SetTrigger("Attack");
        // You would typically also handle the logic for the attack here
        // This could involve checking for a hit, applying damage, etc.
        Debug.Log("Enemy Attacked!");
    }
}
