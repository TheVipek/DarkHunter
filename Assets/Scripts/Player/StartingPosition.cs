using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartingPosition : MonoBehaviour
{
    static bool firstLaunch = true;
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene , LoadSceneMode mode)
    {
        if (!firstLaunch)
        {
            if (scene.name == "MainScene")
            {
                if (PlayerPrefs.HasKey("posX") && PlayerPrefs.HasKey("posY"))
                {
                    gameObject.transform.position = new Vector2(PlayerPrefs.GetFloat("posX"), PlayerPrefs.GetFloat("posY"));
                }

            }

        }
        else
        {
            firstLaunch = false;
        }
        
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}
