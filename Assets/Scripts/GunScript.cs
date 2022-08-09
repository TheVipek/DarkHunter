using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{

    public Text ammoUI;
    
    public float shootCooldown = 0.5f;
    float nextShoot;

    public int Ammo = 1;
    public bool infiniteAmmo;

    public GameObject myPlayer, bullet, shootPoint, shootEffect;


    private void FixedUpdate()
    {
        Rotate();
    }

    private void Update()
    {
        Shoot();

        
        if (ammoUI != null)
        {
            ammoUI.text = Ammo.ToString();
        }

    }

   
    
    
    
    void Rotate()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
       
        if (rotationZ < -90 || rotationZ > 90)
        {
            if (myPlayer.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (myPlayer.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }

        }
    }


    
    
    void Shoot()
    {
       
       // If infinte Ammo is activated do this
        if(infiniteAmmo == true)
        {
            if (Time.time > nextShoot)
            {
                if (Input.GetButtonDown("Fire1"))
                {

                    SoundManager.PlaySound("shoot");
                    Instantiate(shootEffect, shootPoint.transform.position, Quaternion.identity);
                    Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);

                    nextShoot = Time.time + shootCooldown;

                }

            }
        }
        else // if it is false use Ammo instead
        {
            if (Time.time > nextShoot)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    if (Ammo > 0)
                    {
                        SoundManager.PlaySound("shoot");
                        Instantiate(shootEffect, shootPoint.transform.position, Quaternion.identity);
                        Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation);
                        Ammo--;
                        nextShoot = Time.time + shootCooldown;
                    }

                }

            }
        }
        
        
 
    }

}
