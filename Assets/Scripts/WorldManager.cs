using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public uint lifes=1;
     [SerializeField] GameObject life1;
  [SerializeField] GameObject life2;
     [SerializeField] GameObject life3;

     GameObject lifeHead;
     [SerializeField] new ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
       
 lifeHead=GameObject.Find("Head (3)");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifes<1)
        {
            lifes=1;
        }
        
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


    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="life")
        {
            particleSystem.Play();
            lifes++;
        }
    }
}
