using UnityEngine;

public class ExitListener : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Exit>())
            SceneManager.RestartScene();
    }
}
