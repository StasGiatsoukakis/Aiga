using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
  private Animator animator;
  private Rigidbody2D rb2d;
  private bool grounded;
  bool MushroomJump;

  public bool OnAttack;

  [SerializeField] AudioClip footsteps;
  
  [SerializeField] AudioSource audioSource;
[SerializeField] AudioSource boostedJump;
  

[SerializeField] AudioSource jump;
//i use the onAir boolean so my player doesn't get stack on air pushing a wall
  private bool onAir;
  private bool attacked;

  public float movespeed=15f;
  public float jumpHeight=15f;
    // Start is called before the first frame update


   
    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
        
    }
    // Update is called once per frame
    void Update()
    {
//////////////////////////////////////////////////////////////
//JUMP

    
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


        //////////////////////////////////////////////////////////////
//MOVE RIGHT
        
        if(Input.GetKey(KeyCode.D)&& onAir==false)
        {
             if(!audioSource.isPlaying){
                if(grounded==true)
                {
                        audioSource.PlayOneShot(footsteps);
                }
            
          }
             
    //for flipping the character back
    this.transform.rotation=Quaternion.Euler(new Vector3(0f,0,0));


    rb2d.velocity = new Vector2( movespeed, rb2d.velocity.y);
            // transform.Translate(0.02f,0,0);
             if(grounded==true)
             {

animator.SetBool("IsWalking",true);
             }
             else if(Input.GetKey(KeyCode.Space)&&grounded!=true)
             {
                animator.SetBool("jumping",true);
             }
            
             
                 
        }
     //////////////////////////////////////////////////////////////
//MOVE LEFT
       else if(Input.GetKey(KeyCode.A)&& (onAir==false))
        {
            if(!audioSource.isPlaying){
                if(grounded==true)
                {
            audioSource.PlayOneShot(footsteps);

                }

          }
               //for flipping the character to the left

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


         else
        {
            audioSource.Stop();
           
                animator.SetBool("IsWalking",false);
            
             
        }

//////////////////////////////////////////////////////////////
//ATTACK
        if(Input.GetKeyDown(KeyCode.F)&&attacked==false)
        {
           OnAttack=true;
            rb2d.velocity=transform.right*50f;
             animator.SetBool("attacking",true);
             attacked=true;

              StartCoroutine(StartCountDown());
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

   
}
