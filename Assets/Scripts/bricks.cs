using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bricks : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] GameObject brick1;
       [SerializeField] GameObject brick2;
      

    // Start is called before the first frame update
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if((brick1==null)&&(brick2==null))
        {
             rb2d.constraints = RigidbodyConstraints2D.None;

             Destroy(this.gameObject,10f);

           
        }

        
    }
}
