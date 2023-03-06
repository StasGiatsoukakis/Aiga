using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animator;
   
      WorldManager worldManager;
      Controller controller;
     [SerializeField] Transform RespawnPossition;
    // Start is called before the first frame update
    void Start()
    {
        worldManager=GetComponent<WorldManager>();
        animator=GetComponent<Animator>();
        controller=GetComponent<Controller>();
        
    }

    // Update is called once per frame
   
        
     
      void OnTriggerEnter2D(Collider2D other)
      {
          if(other.gameObject.tag=="enemy")
            {
                 StartCoroutine(StartCountDown());
                 --worldManager.lifes;
                 
            }
      }

      
      void OnCollisionEnter2D(Collision2D other)
      {
        
        
        if((other.gameObject.tag=="enemy")&&controller.OnAttack==false)
            {
               
               
                 StartCoroutine(StartCountDown());
                 --worldManager.lifes;
                 
            }
          
      }

      IEnumerator StartCountDown()
    {

      
        yield return new WaitForSecondsRealtime(1);
           transform.position = RespawnPossition.position;
        
    }
    }

