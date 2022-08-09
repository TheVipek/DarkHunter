using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningCondition1 : MonoBehaviour
{

    //Game1
    [SerializeField]
    public float time_to_survive;
    private bool beaten = false;
    private float elapsed_time;

   
    
    

    //lasers
    public GameObject laserObject;
    private LaserSpawner laserController;

    //key
    public GameObject key;
    private KeyInteract keySpawner;

    //teleport

    public GameObject teleport_spawn;
    void Start()
    {
        keySpawner = key.GetComponent<KeyInteract>();
        laserController = laserObject.GetComponent<LaserSpawner>();
 

        time_to_survive = Time.deltaTime + time_to_survive - 0.02f;

    }

    void Update()
    {
       
        
        // Level 1
        elapsed_time += Time.deltaTime;
        if (elapsed_time > time_to_survive && beaten == false)
        {

            beaten = true;
            StartCoroutine(delay());

            if (laserController != null)
            {
                laserController.spawnBombs = false;
                laserController.spawnLaser = false;
            }

            if (keySpawner != null)
            {
                keySpawner.Invoke("ShowKey", 0.15f);
            }



        }


      
        
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.5f);
        teleport_spawn.SetActive(true);
    }
}
