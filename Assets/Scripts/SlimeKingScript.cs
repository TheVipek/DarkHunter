using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeKingScript : MonoBehaviour
{
    public Transform position1, position2;
    public float Speed = 2f;

    public Animator slimeAnimation, keyAnimation;
    public HealthBar healthBar;
    Vector3 nextPosition;
    public Transform startPosition;
    Rigidbody2D rb;
    public GameObject rockPrefab, ground, portal, spikes;


    public float spawnCooldown = 2f;
    float nextSpawn;

    public float jumpForce = 6f;

    bool isGrounded;
    bool timeToAttack;

    public int bulletDmg = 15;
    public int maxHealth = 100;
    int currentHealth;

    int times;


    public bool BulletOnGroundSpawn;
    public bool bigAttack;
    public bool specialAttacks;
    
    SpriteRenderer color;
    Color defaultColor;

    public static bool Level4Completed; 

    private void Start()
    {
        color = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;
        defaultColor = color.color;


        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
        }

      
        nextPosition = startPosition.position;
        
        

    }

    void Action()
    {
        if (currentHealth > 0)
        {


            if (specialAttacks)
            {
                faster();
                BigAttack();
            }

            Move();

            SpawnBullets();

            
            StartCoroutine(Jump());
            
        }
    }

    private void Update()
    {

      
        
        
        Invoke("Action", 1.5f);
           

        if (currentHealth <= 0)
        {
            Level4Completed = true;
            CameraShake.isShaking = true;
            slimeAnimation.SetTrigger("die");
           
        }
        else
        {
            Level4Completed = false;
        }

        if (Level4Completed)
        {
            keyAnimation.SetTrigger("show");
            portal.SetActive(true);
            spikes.SetActive(false);
        }
        else
        {

            portal.SetActive(false);
            spikes.SetActive(true);
        }
    }

   
    void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }
       
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(position1.position, position2.position);
    }



    void SpawnBullets()
    {
        if (BulletOnGroundSpawn)
        {
            if (Time.time > nextSpawn)
            {
                if (isGrounded == true)
                {
                    Instantiate(rockPrefab, transform.position, Quaternion.identity);

                    nextSpawn = Time.time + spawnCooldown;
                }

            }
        }
        else
        {
            if (Time.time > nextSpawn)
            {
                
                    Instantiate(rockPrefab, transform.position, Quaternion.identity);

                    nextSpawn = Time.time + spawnCooldown;
                

            }
        }
       

    }


    IEnumerator Jump()
    {
        if (isGrounded)
        {
            
            yield return new WaitForSeconds(0.11f);

            rb.velocity = new Vector2(0, jumpForce);

            
        }
    }


    void Move()
    {
        if (transform.position == position1.position)
        {
            nextPosition = position2.position;
           

        }

        if (transform.position == position2.position)
        {
            nextPosition = position1.position;
            
        }

        
        //Rotate 
        if (nextPosition == position1.position)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (nextPosition == position2.position)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPosition, Speed * Time.deltaTime);
    }



    IEnumerator ColorChange()
    {
        color.color = new Color(1f, 1f, 1f, 0.3f);

        yield return new WaitForSeconds(0.2f);

        color.color = defaultColor;
    }


    
 
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SoundManager.PlaySound("hit");
            CameraShake.isShaking = true;
            TakeDamage(bulletDmg);
            Destroy(collision.gameObject);
            StartCoroutine(ColorChange());
           
          
        }
       

    }


  


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            
        }
    }




 



    void BigAttack()
    {
        
        

        if (times == 1)
        {
            timeToAttack = false;
            times = 2;
        }

        if (timeToAttack == false)
        {
            if (times == 0)
            {
                if (currentHealth <= 75)
                {
                    timeToAttack = true;
                    times = 1;

                    Instantiate(rockPrefab, new Vector2(0.77f, 5.10f), Quaternion.identity);
                    Instantiate(rockPrefab, new Vector2(1.42f, 5.10f), Quaternion.identity);

                    Instantiate(rockPrefab, new Vector2(3.20f, 5.10f), Quaternion.identity);
                    Instantiate(rockPrefab, new Vector2(4.05f, 5.10f), Quaternion.identity);

                    Instantiate(rockPrefab, new Vector2(6.24f, 5.10f), Quaternion.identity);
                    Instantiate(rockPrefab, new Vector2(7.28f, 5.10f), Quaternion.identity);

                    
                }

                
            } else if (times == 2)
            {
                if (currentHealth <= 20)
                {
                    timeToAttack = true;
                    

                    Instantiate(rockPrefab, new Vector2(0.77f, 5.10f), Quaternion.identity);
                    Instantiate(rockPrefab, new Vector2(1.42f, 5.10f), Quaternion.identity);

                    Instantiate(rockPrefab, new Vector2(3.20f, 5.10f), Quaternion.identity);
                    Instantiate(rockPrefab, new Vector2(4.05f, 5.10f), Quaternion.identity);

                    Instantiate(rockPrefab, new Vector2(6.24f, 5.10f), Quaternion.identity);
                    Instantiate(rockPrefab, new Vector2(7.28f, 5.10f), Quaternion.identity);


                }
            }

           


        }
        
    }

    
    void faster()
    {
        if (currentHealth <= 70)
        {
            Speed = 6;
            spawnCooldown = 0.5f;
            BulletOnGroundSpawn = false;

        } else if (currentHealth <= 50)
        {
            Speed = 7;
            spawnCooldown = 0.4f;
        }
    }
    
   public void AfterAnimation()
    {
        

        Destroy(gameObject, 0.3f);
    }
  
}

   
