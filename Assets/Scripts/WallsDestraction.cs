using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsDestraction : MonoBehaviour
{
    Controller controller;
   
   int cnt=0;
 
   void Start()
   {
       controller=GameObject.Find("GoatCuttedd 1").GetComponent<Controller>();
     

   }
   
   void Update()
   {
    if(cnt==3)
    {
        Destroy(this.gameObject);
     
     
    }
    
       
   }
    void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.tag=="Player")&&(controller.OnAttack==true))
        {
             
              cnt++;
        }
    }
}