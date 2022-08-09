using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{

    public GunScript ammo;

    public GameObject ammoPrefab;

    public float spawnCooldown = 2.5f;
    float nextSpawn;
    


    // Update is called once per frame
    void Update()
    {

        GameObject[] ammosNumber = GameObject.FindGameObjectsWithTag("Ammo");
        int ammoSpawned = ammosNumber.Length;

        

        if (Time.time > nextSpawn)
        {
            if (ammo.Ammo == 0 && ammoSpawned < 2)
            {
                Vector3 randomPosition = new Vector3(Random.Range(0.4f, 8.30f), Random.Range(-3.15f, -6.20f), 0);
               
               
               
                    Instantiate(ammoPrefab, randomPosition, Quaternion.identity);
                
                
                nextSpawn = Time.time + spawnCooldown;
            }
        }
        
    }
}
