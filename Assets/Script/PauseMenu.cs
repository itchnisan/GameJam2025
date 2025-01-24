using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //il faut creer un componeent dans le game manager 
    public GameObject pausedMenuUI;
    private static bool gameIsPaused = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(gameIsPaused){
                Resume();
            }else{
                Paused();
            }
        }
    }

    public void Resume(){
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }


    void Paused(){
        pausedMenuUI.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }


    public void LoadMainMenu(){
        //mettre le dont destroy
        SceneManager.LoadScene("MainMenu");
    }
}
