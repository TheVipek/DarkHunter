using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BarriersController : MonoBehaviour
{
    public int needed_keys;
    public Text amount_keys;
    
    void Start()
    {

 

    }


    void Update()
    {
        //check every frame if player have more or equal needed keys then destroy
        if (int.Parse(amount_keys.text) >= needed_keys)
        {
            Destroy(gameObject);
        }


    }
   

    
}
