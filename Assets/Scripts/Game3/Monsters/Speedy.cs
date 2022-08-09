using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedy : MonoBehaviour
{
    public Animator speedyAnimation;
    
    private bool is_touching_player = false;
    private float next_attack = 0;
    public static MonsterB instance;   
    public GameObject deathEffect, hitEffect;
    private void Awake()
    {
        instance = new MonsterB(40, 3f, 1, 4, false, 0);

    }
    void Update()
    {
        if (!is_touching_player && GameController3.player.transform != null)
        {
         
                instance.FollowPlayer(gameObject.transform, GameController3.player.transform, instance._speed);
                speedyAnimation.SetBool("move", true);
            
            
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.PlaySound("hit");
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            instance.TakeDamage(Bullet.bullet_damage);


            if (instance._hp <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            is_touching_player = true;
            if (Time.time > next_attack)
            {
                SoundManager.PlaySound("hit");
                speedyAnimation.SetBool("move", false);
                GameController3.player.GetComponent<PlayerHealth>().TakeDamage(instance._dmg);
                next_attack = Time.time + instance._attack_cooldown;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            StartCoroutine(touching());
        }
    }
    IEnumerator touching()
    {
        yield return new WaitForSeconds(.5f);
        is_touching_player = false;
        yield return null;
    }
}
