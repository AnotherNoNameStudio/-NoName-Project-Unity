using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneProceeder : MonoBehaviour
{
    public string DestinationSceneName;
    public Image Black;
    public Animator Animator;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        Animator.SetBool("Fade", true);
        yield return new WaitUntil(() => Black.color.a == 1);
        SceneManager.LoadScene(DestinationSceneName);
    }
}
