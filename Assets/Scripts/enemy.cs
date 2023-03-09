using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class enemy : MonoBehaviour
{
    
    [SerializeField] Transform position;
    BoxCollider2D boxCollider2D;
    Controller controller;
    Death death;
  
    
    void Start()
    {
        boxCollider2D=GetComponent<BoxCollider2D>();
  controller=GameObject.Find("GoatCuttedd 1").GetComponent<Controller>();
  death=GameObject.Find("GoatCuttedd 1").GetComponent<Death>();
    }

    
    void Update()
    {
        // position = player.transform.position;
        if(death.death==true)
        {
             boxCollider2D.enabled=false;
           transform.position = Vector2.MoveTowards(transform.position, position.position, 50f*Time.deltaTime);
        }
       
          
    }
   
}
