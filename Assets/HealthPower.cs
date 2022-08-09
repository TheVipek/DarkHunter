using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPower : MonoBehaviour
{

    public GameObject particles;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
           if (PlayerHealth.currentHealth < 5)
            {
                PlayerHealth.currentHealth += 1;               
            }

            SoundManager.PlaySound("collect");
            Instantiate(particles, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
