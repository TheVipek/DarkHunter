using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPowerUp : MonoBehaviour
{
   GunScript ammo;

    private void Start()
    {
        ammo = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunScript>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            SoundManager.PlaySound("collect");
            
            if (ammo != null)
            {
                ammo.Ammo++;
            }
            
            Destroy(gameObject);
        }
    }
}
