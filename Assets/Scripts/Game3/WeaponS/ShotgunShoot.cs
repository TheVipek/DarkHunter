using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [Header("variables")]
    [SerializeField]
    private float speed_of_bullet;
    private float shoot_cooldown;
    public float shotgun_spread;
    private Quaternion angle;
    private void Awake()
    {

    }
    void Start()
    {
        shoot_cooldown = Shotgun.shotgun._cooldown;
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && AmmoController.current_ammo_amount <= 0)
        {
            SoundManager.PlaySound("noammo");
        }
        
        
        //IF USER CLICKS RELOAD BUTTON DO RELOAD
        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.PlaySound("reload");
            AmmoController.current_ammo_amount = Shotgun.shotgun.Reload();

        }

        
        /* -------Here's you shooting script--------
         
        //CALCULATING HOW MUCH TIME PASSED SINCE LAST SHOOT
        shoot_cooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0)  && AmmoController.current_ammo_amount > 0)
        {

           if (shoot_cooldown >= Shotgun.shotgun._cooldown)
            {
                
                
                for (int i = 0; i < 4; i++)
                {
                    angle = Quaternion.AngleAxis(angle_ax, Vector3.forward);
                    GameObject bullet_instance = Instantiate(bullet, position: GameController3.player.transform.position, angle);
                    bullet_instance.GetComponent<Rigidbody2D>().velocity = transform.right * speed_of_bullet;
                    Debug.Log(bullet_instance);
                    AmmoController.current_ammo_amount -= 1;
                    angle_ax += 2f;

                }
                angle_ax = -4f;
                shoot_cooldown = 0;

            }


        }
        */


        //-----------------Changed the shotgun to shoot 1 bullet for now the one above is the one you left-----------
        shoot_cooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && AmmoController.current_ammo_amount > 0)
        {
            if (shoot_cooldown >= Shotgun.shotgun._cooldown)
            {
               /* Debug.Log(GameController3.player.transform.rotation.eulerAngles);
                Debug.Log(transform.rotation.z);

                List<GameObject> bullets;
                if(transform.rotation.z == 0)
                {
                bullets = new List<GameObject>
                    {
                        Instantiate(bullet, position: GameController3.player.transform.position, Quaternion.Euler(0,0,-15)),
                        Instantiate(bullet, position: GameController3.player.transform.position,  Quaternion.Euler(0,0,0)),
                        Instantiate(bullet, position: GameController3.player.transform.position,  Quaternion.Euler(0,0,15)),
                    };
                }
                else
                {
                bullets = new List<GameObject>
                    {
                        Instantiate(bullet, position: GameController3.player.transform.position, Quaternion.Euler(180,0,-15)),
                        Instantiate(bullet, position: GameController3.player.transform.position,  Quaternion.Euler(180,0,0)),
                        Instantiate(bullet, position: GameController3.player.transform.position,  Quaternion.Euler(180,0,15)),
                    };
                }
               
            foreach (var bullet in bullets)
            {

                    bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * speed_of_bullet;
                    AmmoController.current_ammo_amount -= 1;
            } 
                */
                for(int i = 4; i > 0; i--)
                {
                    Debug.Log("shooting x bullets");
                    if(AmmoController.current_ammo_amount > 0)
                    {
                        SoundManager.PlaySound("shoot2");
                        Vector3 dir = transform.right + new Vector3(Random.Range(-shotgun_spread, shotgun_spread), Random.Range(-shotgun_spread, shotgun_spread), Random.Range(-shotgun_spread, shotgun_spread));
                        Debug.Log(angle);
                        GameObject bullet_instance = Instantiate(bullet, position: GameController3.player.transform.position, transform.rotation);
                        bullet_instance.GetComponent<Rigidbody2D>().velocity = dir * speed_of_bullet;
                        AmmoController.current_ammo_amount -= 1;
                        
                    }
                    else
                    {
                        break;
                    }
                  

                }
                shoot_cooldown = 0;
            }

        }

    }
}
