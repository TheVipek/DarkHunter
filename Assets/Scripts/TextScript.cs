using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextScript : MonoBehaviour
{

    TextMeshPro text;
    Scene scene;
    Animator textAnimation;

    public string textName;
    
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {
        scene = SceneManager.GetActiveScene();

        Invoke("ShowText", 0.5f);
    }

    void ShowText()
    {      
        text.text = textName;

        textAnimation.SetTrigger("show");
    }
}
