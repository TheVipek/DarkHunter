using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBullet : MonoBehaviour
{
    Rigidbody2D rb;

    public float bulletSpeed = 5f;

    public GameObject effect;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
        MoveBulletDown();
    }


   

    void MoveBulletDown()
    {
        
            rb.velocity = new Vector2(0, -bulletSpeed);

            Destroy(gameObject, 3);
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stagebarrier")
        {
            SoundManager.PlaySound("destroy");
            Instantiate(effect, transform.position, Quaternion.identity);           
            Destroy(gameObject);
            
        }
    }
}
