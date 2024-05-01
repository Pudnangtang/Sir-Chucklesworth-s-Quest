using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject bloodEffect;

    public Vector2 knockbackForce; 

    private Rigidbody2D rb; // Rigidbody2D component for applying forces

    [SerializeField] FloatingHealthBar healthBar;
    private Transform player;
    public float knockbackDuration;

    public EnemyManager enemyManager;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        rb = GetComponent<Rigidbody2D>(); // Make sure the enemy has a Rigidbody2D component
        rb.drag = 5; 
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player"); 
        if (playerGameObject != null)
        {
            player = playerGameObject.transform;
        }
        else
        {
            Debug.LogError("Player not found: Check if the player GameObject is tagged correctly.");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        //play hurt sound
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        currentHealth -= damageAmount;
        healthBar.UpdateHealthBar(currentHealth, maxHealth);
        Knockback();
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            
        }
    }

    void Knockback()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set in Knockback.");
            return;
        }

        // Calculate direction from player to enemy
        Vector2 knockbackDir = (transform.position - player.position).normalized;

        // Apply the force in that direction
        rb.AddForce(knockbackDir * knockbackForce, ForceMode2D.Impulse);

        // Reset velocity after a short delay
        StartCoroutine(ResetVelocity());
    }

    IEnumerator ResetVelocity()
    {
        yield return new WaitForSeconds(knockbackDuration); // Wait for the specified knockback duration
        rb.velocity = Vector2.zero; // Reset the enemy's velocity
    }

    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // Destroy the enemy object

        enemyManager.EnemyDefeated();
    }
}

