using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class DontDestroyMusic : MonoBehaviour
{
    Scene scene;
    AudioSource source;

    public AudioClip music;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Music");

        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }



    private void Update()
    {
        scene = SceneManager.GetActiveScene();


        if (scene.name == "5" || scene.name == "1" || scene.name == "4" || scene.name == "3.1")
        {
            Destroy(gameObject);
        }

    }



}

