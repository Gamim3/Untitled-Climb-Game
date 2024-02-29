using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class GravityWhileClimbing : MonoBehaviour
{
    public bool isAttachedL, isAttachedR;
    public DynoJump dynojump;
    public bool rHand;
    public bool lHand;
    public bool ziplineInHand;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject moveProvider;
    //public XRDirectInteractor leftDirectGrab;
    //public XRDirectInteractor rightDirectGrab;
    public InputActionProperty leftSelectvalue;
    public InputActionProperty rightSelectvalue;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f) 
            
        {
            isAttachedL = true;
           
        }
        else if(other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)
        {
            isAttachedR = true;
        }
        if (other.CompareTag("Zipline") && leftSelectvalue.action.ReadValue<float>() > 0.1f && rightSelectvalue.action.ReadValue<float>() > 0.1f)
        {
            ziplineInHand = true;
        }
        else
        {
            ziplineInHand = false;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f || other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)

        {
           
            dynojump.onWall = true;
        }

        

    }
    private void OnTriggerExit(Collider other)
    {
        isAttachedL = false;
        isAttachedR = false;
        dynojump.onWall = false;
    }

    
    
}
