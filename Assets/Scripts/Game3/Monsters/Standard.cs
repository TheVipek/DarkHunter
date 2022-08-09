using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standard : MonoBehaviour
{
    private bool is_touching_player = false;
    private float next_attack = 0;
    public static MonsterB instance;
    public GameObject deathEffect, hitEffect;
    public Animator MonsterAnimation;

    void Start()
    {
        instance = new MonsterB(70, 2f, 1, 7, false, 0);
    }

    void Update()
    {
        if (!is_touching_player && GameController3.player.transform != null)
        {

            instance.FollowPlayer(gameObject.transform, GameController3.player.transform, instance._speed);
            MonsterAnimation.SetBool("move", true);
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
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            is_touching_player = true;
            MonsterAnimation.SetBool("move", false);
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
        yield return new WaitForSeconds(1f);
        is_touching_player = false;
        yield return null;
    }
}
