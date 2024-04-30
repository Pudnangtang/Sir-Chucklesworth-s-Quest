using UnityEngine;
using UnityEngine.SceneManagement; // Needed for loading scenes

public class GameControls : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Level 1"); // Replace "YourGameScene" with the name of your scene
    }

    public void QuitGame()
    {
        Application.Quit(); // This will only work in a built game, not in the Unity editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // This line allows the quit function to work in the Unity editor
#endif
    }
}
