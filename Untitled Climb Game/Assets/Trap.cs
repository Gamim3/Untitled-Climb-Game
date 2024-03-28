using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float distance;
    public Transform player;
    public Animator animator;


    public void Update()
    {
        ActivateTrapCard();
    }
    public void ActivateTrapCard()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance < 2f )
        {
            animator.Play("Trap");
        }
        else
        {
            animator.Play(null);
        }
    }
}
