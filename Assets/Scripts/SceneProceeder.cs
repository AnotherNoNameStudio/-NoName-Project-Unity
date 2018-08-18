using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneProceeder : MonoBehaviour
{
    public string DestinationSceneName;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(DestinationSceneName);
        }
    }
}
