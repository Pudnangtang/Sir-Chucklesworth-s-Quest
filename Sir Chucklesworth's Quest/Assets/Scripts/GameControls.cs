using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControls : MonoBehaviour
{
    
    public static void SaveLastScene()
    {
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }

    
    public void RetryGame()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "DefaultSceneName");
        SceneManager.LoadScene(lastScene);
    }


    public void PlayNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings; //llops
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit(); 
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; 
#endif
    }
}
