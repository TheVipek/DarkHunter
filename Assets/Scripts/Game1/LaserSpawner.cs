using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public TimerScript timer;
    
    public Transform[] spawnPoints;

    public GameObject laserPrefab, bombPrefab;
   

    public float LaserCooldown, BombCooldown;
    float nextLaserSpawn , nextBombSpawn;

    public bool spawnBombs = true , spawnLaser = true;

    public float targetTime = 85;


    private void Start()
    {
        targetTime = timer.timerValue - 5;
    }


    // Update is called once per frame
    void Update()
    {
        
     /* if (RetryMenu.isRetryMenu == true)
        {
            spawnBombs = false;
            spawnLaser = false;
        }
     */
        
        
        
        // Deacrease LaserCooldow each 5 seconds 
        if (timer.timerValue < targetTime)
        {
            LaserCooldown -= 0.07f;
            BombCooldown -= 0.06f;
            
            targetTime -= 5f;
        }

        if (targetTime <= 0)
        {
            targetTime = 0;
        }
       
        
       
      
        // Stop spawning after the time ends else continue spawning
   /*     if (timer.timerValue <= 0)
        {
            spawnLaser = false;
            spawnBombs = false;
        }
        else
        {
            spawnLaser = true;
            spawnBombs = true;
        }
     */   
        
       
        
        
        // Spawn Lasers
       if (spawnLaser == true)
        {
            if (Time.time > nextLaserSpawn)
            {
                int i = Random.Range(0, spawnPoints.Length);

                if (i == Random.Range(0, 17))
                {
                    StartCoroutine(waitSound("explode"));
                    Instantiate(laserPrefab, spawnPoints[i].position, Quaternion.identity);
                }
                else if (i == Random.Range(18, 27))
                {
                    StartCoroutine(waitSound("explode"));

                    Instantiate(laserPrefab, spawnPoints[i].position, Quaternion.Euler(0, 0, 90));
                }


                nextLaserSpawn = Time.time + LaserCooldown;
            }
        }

       if (LaserCooldown <= 0.02f)
        {
            LaserCooldown = 0.02f;
        }
        
        


        //Spawn Bombs
            if (spawnBombs == true)
         {
            if (Time.time > nextBombSpawn)
            {
                float randomX = Random.Range(-8.04f, 8.04f);
                float randomY = Random.Range(3.60f, -6.11f);

                Instantiate(bombPrefab, new Vector2(randomX, randomY), Quaternion.identity);

                
                StartCoroutine(waitSound("laser"));

                nextBombSpawn = Time.time + BombCooldown;
            }
        }

            if (BombCooldown <= 0.3f)
        {
            BombCooldown = 0.3f;
        }

    }

    IEnumerator waitSound(string sound)
    {
        yield return new WaitForSeconds(0.3f);
        SoundManager.PlaySound(sound);
    }
}
