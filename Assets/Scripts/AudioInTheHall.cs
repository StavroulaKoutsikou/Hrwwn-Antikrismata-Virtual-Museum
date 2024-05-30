using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInTheHall : MonoBehaviour
{
   
    public AudioSource source;
    public AudioClip clip;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            source.PlayOneShot(clip);
        }
    }
}
