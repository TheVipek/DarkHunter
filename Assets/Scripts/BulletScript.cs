using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Rigidbody2D rb;

    public float bulletSpeed = 20f;

    public bool moveBulletDown;
    public bool moveAnyDirection = true;
    
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();

        MoveBulletAnyDirection();
        MoveBulletDown();
    }

    
    
    void MoveBulletAnyDirection()
    {
       
       if (moveAnyDirection)
        {
            rb.velocity = transform.right * bulletSpeed;

            Destroy(gameObject, 3);
        } 
       
    }

    void MoveBulletDown()
    {
        if (moveBulletDown)
        {
            rb.velocity = new Vector2(0, - bulletSpeed);
            
            Destroy(gameObject, 3);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stagebarrier" || 
            collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
