using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //clique sur canvas pour changer le levelto load
    public string levelToLoad = "aaa.unity";//le level a charger mais si y'en a qu'un ou rentre en dur

    public GameObject OptionsPanel;
    public void StartGame()
    {
        SceneManager.LoadScene("Game-Test");
    }
    public void OptionsButton()
    {
        OptionsPanel.SetActive(true);
    }
    public void QuitOptions()
    {
        OptionsPanel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
