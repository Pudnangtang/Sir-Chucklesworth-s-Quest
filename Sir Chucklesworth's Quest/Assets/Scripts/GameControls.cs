using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    // Call this method at the start or end of a scene to save it as the last scene
    public static void SaveLastScene()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }

    // Method to retry the game by loading the last played scene
    public void RetryGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "DefaultSceneName");
        SceneManager.LoadScene(lastScene);
    }

    // Method to load the next scene in the build order
    public void PlayNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; // Loops back to the first scene if it's the last one
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit(); // This will only work in a built game, not in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // This line allows the quit function to work in the Unity editor
#endif
    }
}
