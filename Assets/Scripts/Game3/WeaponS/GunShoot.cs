using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [Header("variables")]
    [SerializeField]
    private float speed_of_bullet;
    private float shoot_cooldown;

    private void Awake()
    {

    }
    void Start()
    {
        shoot_cooldown = Gun.gun._cooldown;

        //GETTING WHAT PLAYER SELECTED

        //MAX AMMO
        //CURRENT
        //bullet damage


    }
    void Update()
    {
       
        if (AmmoController.current_ammo_amount <= 0 && Input.GetMouseButtonDown(0))
        {
            SoundManager.PlaySound("noammo");
        }
        
        
        //IF USER CLICKS RELOAD BUTTON DO RELOAD
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.PlaySound("reload");
            AmmoController.current_ammo_amount = Gun.gun.Reload();

        }

        //CALCULATING HOW MUCH TIME PASSED SINCE LAST SHOOT
        shoot_cooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && shoot_cooldown >= Gun.gun._cooldown && AmmoController.current_ammo_amount > 0)
        {
            SoundManager.PlaySound("shoot2");
            
            GameObject bullet_instance = Instantiate(bullet, position: GameController3.player.transform.position, Quaternion.identity);
            bullet_instance.GetComponent<Rigidbody2D>().velocity = transform.right * speed_of_bullet;
            shoot_cooldown = 0;
            AmmoController.current_ammo_amount -= 1;

        }
    }
}
