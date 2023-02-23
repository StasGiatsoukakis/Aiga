using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingSound : MonoBehaviour
{

  AudioSource audioSource;
  [SerializeField] AudioClip jump;
    // Start is called before the first frame update
    void Start()
    {
        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space))
                 {
                     audioSource.PlayOneShot(jump);
                 }
    }
}
