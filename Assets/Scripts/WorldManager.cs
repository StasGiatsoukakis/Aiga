using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public int lifes=1;
     [SerializeField] GameObject life1;
  [SerializeField] GameObject life2;
     [SerializeField] GameObject life3;

     GameObject lifeHead;

    // Start is called before the first frame update
    void Start()
    {
       
 lifeHead=GameObject.Find("Head (3)");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(lifes==2)
        {
            life2.SetActive(true);
            Destroy(lifeHead);
        }
        if(lifes<2)
        {
            life2.SetActive(false);
        }
        
    }


    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="life")
        {
            lifes++;
        }
    }
}
