using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryMenu : MonoBehaviour
{

    public static bool isRetryMenu;
    public GameObject retryMenu;

    private void Update()
    {
        if (isRetryMenu == false)
        {
            retryMenu.SetActive(false);
        }
        else
        {
            retryMenu.SetActive(true);
        }
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void Retry()
    {
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
