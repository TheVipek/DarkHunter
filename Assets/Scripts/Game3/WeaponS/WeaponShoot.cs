using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShoot : MonoBehaviour
{
   

    [Header ("Objects")]
    public WeaponSettings weapon_settings;
    [SerializeField]
    GameObject bullet;
    [Header ("variables")]
    public float speed_of_bullet;
    private bool fire_key;
    private float shoot_cooldown;

    [Header ("Ammo controlling")]
    [SerializeField]
    public int ammo_amount;
    [SerializeField]
    public int max_ammo_ps;

    void Start()
    {
        //GETTING WHAT PLAYER SELECTED
       if(gameObject.name == "revolver")
        {
            

        }else if(gameObject.name == "shotgun")
        {
            
        }
        else if(gameObject.name == "rifle")
        {
            
        }
        
        //SETTING BASE VARIABLES
        //CD
        shoot_cooldown = weapon_settings._cooldown;
        //MAX AMMO
        max_ammo_ps = weapon_settings._ammo;
        //CURRENT
        ammo_amount = max_ammo_ps;
        //bullet damage


    }
    void Update()
    {
        //IF USER CLICKS RELOAD BUTTON DO RELOAD
        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo_amount = weapon_settings.Reload();
            
        }

        //CALCULATING HOW MUCH TIME PASSED SINCE LAST SHOOT
        shoot_cooldown += Time.deltaTime;
        fire_key = Input.GetButtonDown("Fire1");

        
        if(fire_key && shoot_cooldown >= weapon_settings._cooldown && ammo_amount > 0)
        {
            //Spawn Particle when shooting
           
            // SHOULD INSTANTIATE BULLET
            // IDEA : SHOTGUN SHOOTING FEW BULLETS
            GameObject bullet_instance = Instantiate(bullet, position: GameController3.player.transform.position,Quaternion.identity);
            
            // bullet_instance.transform.parent = gameObject.transform;
            bullet_instance.GetComponent<Rigidbody2D>().velocity = transform.right * speed_of_bullet;
            shoot_cooldown = 0;
            ammo_amount -= 1;

        }
    }
    
}
