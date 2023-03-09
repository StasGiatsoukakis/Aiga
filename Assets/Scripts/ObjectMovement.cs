using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
     
   public GameObject[] waypoints;
   public float speed;
   private int current=0;
   private float rotSpeed;
   private float WPradius=1;
   
    

   
    void Update()
    {
        

        if(Vector2.Distance(waypoints[current].transform.position,transform.position)<WPradius)
        {
            current++;
            if(current>=waypoints.Length)
            {
                current=0;
            }
        }
        transform.position=Vector2.MoveTowards(transform.position,waypoints[current].transform.position,Time.deltaTime*speed);
        
    }




void OnTriggerEnter2D(Collider2D other)
{
     if(other.gameObject.tag=="fliper1")
        {
             this.transform.rotation=Quaternion.Euler(new Vector3(0f,180f,0));

        }
        if(other.gameObject.tag=="fliper2")
        {
             this.transform.rotation=Quaternion.Euler(new Vector3(0f,0,0));

        }
}


    
}
