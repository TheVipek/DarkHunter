using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoneText : MonoBehaviour
{
    public TextMeshPro stoneText;
    public string keysNedded;


    // Update is called once per frame
    void Update()
    {
        stoneText.text = KeysScript.keys.ToString() + "/" + keysNedded + " Keys";
    }
}
