using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{

    public float spawnCooldown = 2f;
    float nextSpawn;

    Vector2 randomSpawn;


    public GameObject heartPower;

    void Update()
    {
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
        int heartsSpawned = hearts.Length;



        if (Time.time > nextSpawn+spawnCooldown)
        {
            if (heartsSpawned <= 0 && PlayerHealth.currentHealth < 5)
            {
                randomSpawn = new Vector2(Random.Range(14.12f, 28.34f), Random.Range(5.95f, -1.25f));

                Instantiate(heartPower, randomSpawn, Quaternion.identity);
                
            }

            nextSpawn = Time.time + spawnCooldown;
        }



    }
}
