using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanky : MonoBehaviour
{
    private bool is_touching_player = false;
    private float next_attack = 0;
    public static MonsterB instance;
    public GameObject deathEffect, hitEffect;
    public Animator animation;
    void Start()
    {
        instance = new MonsterB(100, 1.5f, 2, 10, false, 0);
    }

    private void Update()
    {
        if (!is_touching_player && GameController3.player.transform != null)
        {

            instance.FollowPlayer(gameObject.transform, GameController3.player.transform, instance._speed);
            animation.SetBool("move", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.PlaySound("hit");
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
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
            animation.SetBool("move", false);
            if (Time.time > next_attack)
            {
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
        yield return new WaitForSeconds(1.5f);
        is_touching_player = false;
        yield return null;
    }
}
