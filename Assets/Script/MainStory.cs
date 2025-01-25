using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{
    public string nextSceneName = "MainMenu"; // Nom de la sc�ne suivante

    
    public float introDuration = 53.68333f; // Dur�e de l'introduction en secondes (par exemple, pour une vid�o ou animation)

    private void Start()
    {
        // Commence la coroutine pour attendre la fin de l'introduction
        StartCoroutine(WaitForIntroEnd());
    }

    private IEnumerator WaitForIntroEnd()
    {
        // Attend la dur�e sp�cifi�e
        yield return new WaitForSeconds(introDuration);

        // Charge la sc�ne suivante
        SceneManager.LoadScene(nextSceneName, LoadSceneMode.Single);
    }
}