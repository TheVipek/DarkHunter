using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [Header("variables")]
    [SerializeField]
    private float speed_of_bullet;
    private float shoot_cooldown=0;


    float soundCooldown = 0.5f;
    float nextSound;
    private void Awake()
    {

    }
    void Start()
    {


    }
    void Update()
    {

        if (Input.GetMouseButton(0) && AmmoController.current_ammo_amount <= 0)
        {
            if (Time.time > nextSound)
            {
                SoundManager.PlaySound("noammo");
                nextSound = Time.time + soundCooldown;
            }
            
        }
        
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.PlaySound("reload");
            AmmoController.current_ammo_amount = Rifle.rifle.Reload();

        }

        //CALCULATING HOW MUCH TIME PASSED SINCE LAST SHOOT
        shoot_cooldown += Time.deltaTime;

        if (Input.GetMouseButton(0) && AmmoController.current_ammo_amount > 0)
        {
            if (shoot_cooldown >= Rifle.rifle._cooldown)
            {
                SoundManager.PlaySound("shoot2");
                Debug.Log("shooting");
                GameObject bullet_instance = Instantiate(bullet, position: GameController3.player.transform.position, Quaternion.identity);
                bullet_instance.GetComponent<Rigidbody2D>().velocity = transform.right * speed_of_bullet;
                AmmoController.current_ammo_amount -= 1;
                shoot_cooldown = 0;
            }

        }

    }
    IEnumerator rifle_shoot()
    {

        for (int i = AmmoController.current_ammo_amount; i >0; i--)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet_instance = Instantiate(bullet, position: GameController3.player.transform.position, Quaternion.identity);
                bullet_instance.GetComponent<Rigidbody2D>().velocity = transform.right * speed_of_bullet;
                AmmoController.current_ammo_amount -= 1;
                yield return new WaitForSeconds(Rifle.rifle._cooldown);
            }
            else
            {
                yield return null;
            }
            
        }
        yield return null;
    }
}
