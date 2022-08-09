using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeysScript : MonoBehaviour
{
    public Text keysText;

    public static int keys;

        

    void Update()
    {
        keysText.text = keys.ToString();

    }
}
