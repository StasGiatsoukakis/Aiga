using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
  private Animator animator;
  private Rigidbody2D rb2d;
  private bool grounded;
  private bool MushroomJump;
  private bool hitting;
  private bool onAir;
  private bool attacked;
  public bool OnAttack;
  public float movespeed=15f;
  public float jumpHeight=15f;

  [SerializeField] AudioClip footsteps;
  [SerializeField] AudioSource audioSource;
  [SerializeField] AudioSource boostedJump;
  [SerializeField] AudioSource hit; 
  [SerializeField] AudioSource jump;

   
    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
        
    }
   
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Space)&&(grounded==true))
        {
            Jump();
            }
        else
        {
              if(MushroomJump!=true)
            {
              animator.SetBool("jumping",false);
            }
        }


        
        if(Input.GetKey(KeyCode.D)&& onAir==false)
        {
            RightMovement();
                    
        }
     
       else if(Input.GetKey(KeyCode.A)&& (onAir==false))
        {
            LeftMovement();
            
        }


         else
        {
            audioSource.Stop();
            animator.SetBool("IsWalking",false);         
        }


        if(Input.GetKeyDown(KeyCode.F)&&attacked==false)
        {
            Attack();
          
        }
    }
   
    void OnCollisionEnter2D(Collision2D other)
    {
         if((other.gameObject.tag=="brick")&&(OnAttack==true))
        {
            
               hitting=true;
        }
        else
        {
              hitting=false;
        }
        
    }

   
    void OnCollisionStay2D(Collision2D other)
    {
        
        
        
        if(other.gameObject.tag=="ground")
        {
            grounded=true;
        }
        
        if(other.gameObject.tag=="side")
        {
           onAir=true;
        }
       
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
         if(other.gameObject.tag=="ground")
        {
            grounded=false;
        }
        if(other.gameObject.tag=="side")
        {
           onAir=false;
        }

        if(other.gameObject.tag=="mushroom")
        {

             rb2d.velocity = new Vector2(rb2d.velocity.x,jumpHeight*2f);
             MushroomJump=true;
             animator.SetBool("jumping",true);
             boostedJump.Play();
             StartCoroutine(StartCountDownJump());
        }
     
        
        
    }
    IEnumerator StartCountDown()
    {
        yield return new WaitForSecondsRealtime(1);
         animator.SetBool("attacking",false);
         attacked=false;
         OnAttack=false;
        
    }
     IEnumerator StartCountDownJump()
    {
        while(grounded==false)
        {
             yield return new WaitForSecondsRealtime(0);
             MushroomJump=false;
        }
    }

      


     void Jump()
    {
                
           jump.Play();
           animator.SetBool("IsWalking",false);
           animator.SetBool("jumping",true);
           rb2d.velocity = new Vector2(rb2d.velocity.x,jumpHeight);
                
    }
    void RightMovement()
    {
             if(!audioSource.isPlaying)
             {
                if(grounded==true)
                {
                    audioSource.PlayOneShot(footsteps);
                }
             }
            //flipping the character
             this.transform.rotation=Quaternion.Euler(new Vector3(0f,0,0));

             rb2d.velocity = new Vector2( movespeed, rb2d.velocity.y);
            
             if(grounded==true)
             {
                 animator.SetBool("IsWalking",true);
             }
             else if(Input.GetKey(KeyCode.Space)&&grounded!=true)
             {
                animator.SetBool("jumping",true);
             }
    }

    void LeftMovement()
    {
        if(!audioSource.isPlaying)
        {
            if(grounded==true)
            {
                audioSource.PlayOneShot(footsteps);
            }
        }
               
          //flipping the character
         this.transform.rotation=Quaternion.Euler(new Vector3(0f,180f,0));

         rb2d.velocity = new Vector2( -movespeed, rb2d.velocity.y);
            
 
            if(grounded==true)
            {
                animator.SetBool("IsWalking",true);
            }
            else if(Input.GetKey(KeyCode.Space)&&grounded!=true)
            {
                animator.SetBool("jumping",true);
            }
    }

    void Attack()
    {
            OnAttack=true;
            rb2d.velocity=transform.right*50f;
            animator.SetBool("attacking",true);
            attacked=true;
             if(hitting==true)
             {
                if(!hit.isPlaying)
                {
                 hit.Play();
                }
             }
            StartCoroutine(StartCountDown());
    }

   
}
