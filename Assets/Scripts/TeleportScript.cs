using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScript : MonoBehaviour
{

    public string sceneName;
    public float timer;
    public int keysNeeded;

    public LevelLoader levelLoader;
    public Animator portalAnimation;

    //public Transform teleportPoint;

    public GameObject eText;
    
    //Scene scene;

    //bool portalShown;

 


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eText.transform.position = new Vector3(transform.position.x + 0.6f, transform.position.y + 0.8f, 0);

            if (KeysScript.keys >= keysNeeded){
                eText.SetActive(true);
            }
            else {     
                eText.SetActive(false);
            }

           // If "e" pressed and the player has enough keys to enter the teleport
            if (Input.GetKey(KeyCode.E) && KeysScript.keys >= keysNeeded)
            {
                if(SceneManager.GetActiveScene().name == "MainScene"){
                    SoundManager.PlaySound("teleport");
                    PlayerPrefs.SetFloat("posX", collision.gameObject.transform.position.x);
                    PlayerPrefs.SetFloat("posY", collision.gameObject.transform.position.y);
                    levelLoader.SceneLoad(sceneName);
                }
                else
                {
                    levelLoader.SceneLoad(sceneName);
                }

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            eText.SetActive(false);
        }
    }



    
    
}
