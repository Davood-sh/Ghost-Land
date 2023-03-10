using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public string mainMenu;
   public static bool isGamePause = false;    
   [SerializeField] GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;

    }
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(mainMenu);

    }
    
    public void QuitGame()
    {
        Application.Quit();

    }

}
