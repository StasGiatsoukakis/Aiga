using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
  [SerializeField] Transform RespawnPossition;
  [SerializeField] Transform EnemyRespawnPossition;
  [SerializeField] new ParticleSystem particleSystem;
  Animator animator;
  WorldManager worldManager;
  Controller controller;
  [SerializeField]enemy enemy;
  [SerializeField]GameObject HeadgeHog;
 [SerializeField] BoxCollider2D boxCollider2D;

  public bool death;
      
    void Start()
    {
        worldManager=GetComponent<WorldManager>();
        animator=GetComponent<Animator>();
        controller=GameObject.Find("GoatCuttedd 1").GetComponent<Controller>();
        enemy=GameObject.Find("hedgehog(Clone)").GetComponent<enemy>();
        HeadgeHog=GameObject.Find("hedgehog(Clone)");
        boxCollider2D=GameObject.Find("hedgehog(Clone)").GetComponent<BoxCollider2D>();
   }

   void Update()
   {
   
    
   }
        
     
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
               particleSystem.Play();
               controller.enabled=false;
               --worldManager.lifes;
                death=true;
                enemy.enabled=true;
               StartCoroutine(StartCountDown());
               
            }
           
          
      }

      IEnumerator StartCountDown()
    {
      yield return new WaitForSecondsRealtime(1f);
         enemy.enabled=false;
       transform.position = RespawnPossition.position;
       
       controller.enabled=true;
        particleSystem.Stop();
        death=false;
         enemy=GameObject.Find("hedgehog(Clone)").GetComponent<enemy>();
        HeadgeHog=GameObject.Find("hedgehog(Clone)");
        boxCollider2D=GameObject.Find("hedgehog(Clone)").GetComponent<BoxCollider2D>();

       
    }



}

