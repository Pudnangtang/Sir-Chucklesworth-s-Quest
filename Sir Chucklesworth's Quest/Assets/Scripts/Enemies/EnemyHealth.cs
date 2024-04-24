using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public GameObject bloodEffect;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        //play hurt sound
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Optional: Add some logic here for what happens when the enemy takes damage
            // but is not yet dead, like playing a damage animation.
        }
    }

    private void Die()
    {
        // Here you can add what happens when the enemy dies, like playing an animation,
        // disabling the enemy, or destroying the enemy object.
        Debug.Log("Enemy died!");

        // This line would destroy the enemy object when health reaches 0.
        Destroy(gameObject);
    }
}

