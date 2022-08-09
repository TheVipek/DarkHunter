using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public static int bullet_range;
    public static int bullet_damage;

    public GameObject particle;
    void Update()
    {
        if(Mathf.Abs(Vector3.Distance(gameObject.transform.position,GameController3.player.transform.position))> bullet_range)
        {
            Instantiate(particle, transform.position, Quaternion.identity) ;
            Destroy(gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider)
        {
            Destroy(gameObject);
        }
    }
}
