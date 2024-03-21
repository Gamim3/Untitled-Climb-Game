using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator animatorWall,animatorRoof,animatorRoof2;
    public bool wall,stopTimer;
    public float timer = 8;

    public void Start()
    {
        stopTimer = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        
       if(other.tag == "Player")
       {
            Debug.Log("Animatie");
            animatorRoof.SetBool("RoofSide1",true);
            animatorRoof2.SetBool("RoofSide2",true);
            stopTimer = false;
       }
        
        //if(animatorRoof.)


    }
    public void Update()
    {
        if(!stopTimer)
        {
            timer -= Time.deltaTime;
        }
       
        if(timer <=0)
        {
            animatorWall.SetBool("Wall",true);
            stopTimer = true;
        }

    }
}
