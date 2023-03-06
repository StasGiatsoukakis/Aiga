using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update

    Controller controller;
    ObjectMovement ObjectMovement;
    void Start()
    {
        controller=GameObject.Find("GoatCuttedd 1").GetComponent<Controller>();
        ObjectMovement=GetComponent<ObjectMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.tag=="Player") && (controller.OnAttack==true))
        {
            ObjectMovement.enabled=false;
        StartCoroutine(StartCountDown());


        }
        
    }
    
    IEnumerator StartCountDown()
    {
        yield return new WaitForSecondsRealtime(1);
        
        Destroy(this.gameObject);
        
    }
}
