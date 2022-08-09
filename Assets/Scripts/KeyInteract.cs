using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInteract : MonoBehaviour
{

    //public TimerScript timer;
    public Animator keyAnimation;

    public GameObject key, particle;
    public int keysToDestroy;
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("collect");
            KeysScript.keys += 1;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    private void Update()
    {
       if (KeysScript.keys >= keysToDestroy)
        {
            Destroy(key);
        }
      
    }


    void ShowKey()
    {
        keyAnimation.SetTrigger("show");
    }

}
