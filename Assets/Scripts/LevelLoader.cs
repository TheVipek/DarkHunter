using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator fade;
   
    
    
    // Transitions
    IEnumerator LoadScene(string scene)
    {
        fade.SetTrigger("start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(scene);
    }

    IEnumerator Restart()
    {
        fade.SetTrigger("start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    // Load Scenes
    public void SceneLoad(string _scene)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadScene(_scene));
    }



    public void ExitButton()
    {
        Application.Quit();
    }



    public void RestartScene()
    {
        StartCoroutine(Restart());

    }
}
