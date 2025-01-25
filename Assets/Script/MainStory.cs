using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public string nextSceneName = "MainMenu"; // Nom de la scène suivante

    
    public float introDuration = 53.68333f; // Durée de l'introduction en secondes (par exemple, pour une vidéo ou animation)

    private void Start()
    {
        // Commence la coroutine pour attendre la fin de l'introduction
        StartCoroutine(WaitForIntroEnd());
    }

    private IEnumerator WaitForIntroEnd()
    {
        // Attend la durée spécifiée
        yield return new WaitForSeconds(introDuration);

        // Charge la scène suivante
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}