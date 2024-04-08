using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlaySound : MonoBehaviour
{
    public AudioSource hit;
    public AudioClip gotHit;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            hit.PlayOneShot(gotHit);
            
        }
    }
}
