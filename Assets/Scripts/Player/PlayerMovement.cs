using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Scene scene;
    public Animator playerAnimation;
    public float speed = 5f;
    public float jumpForce = 5f;

    //Dash
    public float dashForce = 15f;
    public float StartDashTimer = 0.25f;   
    float currentDashTimer;
    float dashDirection;
    
    bool isDashing;
    
    float nextDash;
    public float dashCooldown = 0.5f;


    //Movement Type
    public bool moveSideScroll;
    public bool moveTopDown;
    public bool dash;

    //binds
    public float moveX, moveY;
    bool isGrounded;

    // sound cooldown

   
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        scene = SceneManager.GetActiveScene();

        Movement();

    
       
    }

 
    void Movement()
    {
       

        // Move Top-Down
        if (moveTopDown == true)
        {
            //Move
            rb.velocity = new Vector2(moveX, moveY).normalized * speed;

           
        }


        //Move sideScroll
        if (moveSideScroll == true)
        {
            //Move
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y) ;
        
            //Jump
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded == true)
                {
                    SoundManager.PlaySound("jump");
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                   
                }
            }

            if (isGrounded == true)
            {
                playerAnimation.SetBool("isJumping", false);
            }
            else
            {
                playerAnimation.SetBool("isJumping", true);
            }

        }




        //Dash
        if (dash)
        {
         if (Input.GetKeyDown(KeyCode.LeftShift ) && moveX != 0)
            {
                if (Time.time > nextDash)
                {
                    isDashing = true;

                    SoundManager.PlaySound("dash");
                    
                    currentDashTimer = StartDashTimer;

                    rb.velocity = Vector2.zero;

                    dashDirection = moveX;

                    nextDash = Time.time + dashCooldown;
                }               
            }
         if (isDashing)
            {
                

                if (transform.rotation.eulerAngles.y == 0)
                {
                    rb.velocity = transform.right * dashDirection * dashForce;
                }
                else
                {
                    rb.velocity = transform.right * dashDirection * -dashForce;
                }

                

                currentDashTimer -= Time.deltaTime;

                if (currentDashTimer <= 0)
                {
                    isDashing = false;
                }
            }

        }

   
        // Rotation


        if (moveX == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (moveX == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        // Animations

        if (moveX != 0)
        {
            playerAnimation.SetBool("isMoving", true);
        }
        else
        {
            playerAnimation.SetBool("isMoving", false);
        }


       
        if (moveTopDown == true)
        {
            if (moveY == 1)
            {
                playerAnimation.SetBool("isMovingUp", true);
            }

            if (moveY == -1)
            {
                playerAnimation.SetBool("isMovingDown", true);
            }
        }

        if (moveY == 0)
        {
            playerAnimation.SetBool("isMovingUp", false);
            playerAnimation.SetBool("isMovingDown", false);
        }


        if (isDashing == true)
        {
            playerAnimation.SetBool("isDashing", true);
        }
        else
        {
            playerAnimation.SetBool("isDashing", false);
        }



    
        
      
       
    
    }//End of Movement


    
  
   
    
   
    
    
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

}
