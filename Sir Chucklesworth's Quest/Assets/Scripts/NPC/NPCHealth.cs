using UnityEngine;
using UnityEngine.SceneManagement; // Add this if you're using scenes to restart the game

public class NPCHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("NPC Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("NPC has died!");

        // If you want to play a game over scene or restart the game, you can call a SceneManager to load the scene
        // Example: SceneManager.LoadScene("GameOverScene"); // Make sure to replace "GameOverScene" with your actual scene name
    }
}
