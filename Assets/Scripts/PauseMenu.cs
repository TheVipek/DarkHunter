using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    bool isPaused = false;

    public GameObject pauseMenu;





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
           
           if (RetryMenu.isRetryMenu == false)
            {
                if (isPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }        
        }


        if (isPaused == true)
        {
            pauseMenu.SetActive(true);
        }
        else
        {
            pauseMenu.SetActive(false);
        }

      
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }


    void Pause()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
