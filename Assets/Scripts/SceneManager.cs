using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(int sceneBuildIndex)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex);
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
