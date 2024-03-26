using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundWind : MonoBehaviour
{
    // Start is called before the first frame update
   public AudioSource audioSource;
   
   public void OnTriggerEnter(Collider other)
   {
        if(other.tag == "Player")
        {   
            audioSource.enabled = true;
        }
   }
    public void OnTriggerExit(Collider other)
    {
        audioSource.enabled = false;
    }

}
