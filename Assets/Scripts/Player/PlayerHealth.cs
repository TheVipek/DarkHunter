using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //PlayerHealth
    public int maxHealth = 100;
    public static int currentHealth;

    //Dmg
    public int laserDmg = 25;

    //References
    public HealthBar healthbar;
    public GameObject deathEffect;

    //Color
    SpriteRenderer playerColor;
    Color defaultColor;

    
    //Heart Health

    public int numOfHearts;

    public Image[] hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;


    void Start()
    {
        playerColor = GetComponent<SpriteRenderer>();
        healthbar = healthbar.GetComponent<HealthBar>();
       
        defaultColor = playerColor.color;      
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

   
   // Take Damage
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthbar.SetHealth(currentHealth);
    }

   
    
    void Update()
    {
        Die();

        //Heart System
        
        if (currentHealth > numOfHearts)
        {
            currentHealth = numOfHearts;
        }
        
        
        
        for (int i = 0; i < hearts.Length; i++)
        {
            
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            
            
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
        
    }
    
    
    
   
    
    void Die()
    {
        // What happens when you die
        if (currentHealth <= 0)
        {
            CameraShake.isShaking = true;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            RetryMenu.isRetryMenu = true;

        }
        else
        {
            RetryMenu.isRetryMenu = false;
        }
    }
    
    
    
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Laser")
        {
            SoundManager.PlaySound("hit");
            TakeDamage(laserDmg);
            CameraShake.isShaking = true;
            StartCoroutine(ChangeColor());

           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            SoundManager.PlaySound("hit");
            TakeDamage(5);
        }
    }




    // Player Changes color when hit
    IEnumerator ChangeColor()
    {
        playerColor.color = new Color(1f,1f,1f,0.3f);

        yield return new WaitForSeconds(0.2f);

        playerColor.color = defaultColor;  
    }
}
