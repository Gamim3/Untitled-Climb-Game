using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float distance;
    public Transform player;
    public Animator animator;
    public AudioSource trapSound;
    public AudioClip outSound;

    
    public void Update()
    {
        ActivateTrapCard();
        
    }
    public void ActivateTrapCard()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance < 2f )
        {
            trapSound.PlayOneShot(outSound);
            animator.Play("Trap");
        }
        else
        {
            animator.Play(null);
        }
    }
}
