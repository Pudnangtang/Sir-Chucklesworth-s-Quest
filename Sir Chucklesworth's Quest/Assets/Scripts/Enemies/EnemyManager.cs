using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public int totalEnemies;
    public int enemiesDefeated;

    private void Start()
    {
        // Initialize totalEnemies by counting all enemies present at the start or set manually in Inspector
        totalEnemies = FindObjectsOfType<EnemyHealth>().Length;
        enemiesDefeated = 0;
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        CheckAllEnemiesDefeated();
    }

    private void CheckAllEnemiesDefeated()
    {
        if (enemiesDefeated >= totalEnemies)
        {
            // Load next level or perform other actions
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
