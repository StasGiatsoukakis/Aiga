using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
  private Animator animator;
  private Rigidbody2D rb2d;
  private bool grounded;
  [SerializeField] float movespeed=15f;
  [SerializeField] float jumpHeight=15f;
    // Start is called before the first frame update


    
    void Start()
    {
        animator=GetComponent<Animator>();
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    
         if (Input.GetKeyDown(KeyCode.Space)&&grounded==true)
        {
animator.SetBool("IsWalking",false);
           animator.SetBool("jumping",true);

           rb2d.velocity = new Vector2(rb2d.velocity.x,jumpHeight);
                

        }
        else
        {
              animator.SetBool("jumping",false);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
             
    this.transform.rotation=Quaternion.Euler(new Vector3(0f,0,0));
    rb2d.velocity = new Vector2( movespeed, rb2d.velocity.y);
            // transform.Translate(0.02f,0,0);
             if(grounded==true)
             {

animator.SetBool("IsWalking",true);
             }
             else
             {
 animator.SetBool("jumping",true);
             }
             
                 
        }
     
       else if(Input.GetKey(KeyCode.A))
        {
           
           this.transform.rotation=Quaternion.Euler(new Vector3(0f,180f,0));
         rb2d.velocity = new Vector2( -movespeed, rb2d.velocity.y);
            
 
                if(grounded==true)
             {

               animator.SetBool("IsWalking",true);
             }
             else
             {
            animator.SetBool("jumping",true);
             }
        }





         else
        {
             animator.SetBool("IsWalking",false);
        }

       

    }

   
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag=="ground")
        {
            grounded=true;
        }
       
    }
    
    void OnCollisionExit2D(Collision2D other)
    {
         if(other.gameObject.tag=="ground")
        {
            grounded=false;
        }
        
    }
}
