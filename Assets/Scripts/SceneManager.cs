using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static int ActiveBuildIndex => UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
    public static string ActiveName => UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

    public static void LoadScene(int sceneBuildIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex);
    }

    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public static void RestartScene()
    {
        LoadScene(ActiveBuildIndex);
    }
}
