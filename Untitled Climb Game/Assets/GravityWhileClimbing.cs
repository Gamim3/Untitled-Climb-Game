using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class GravityWhileClimbing : MonoBehaviour
{
    public bool isAttached;
    public DynoJump dynojump;
    public bool rHand;
    public bool lHand;
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
        if(other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f || other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)
            
        {
            isAttached = true;
           
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
        isAttached = false;
        dynojump.onWall = false;
    }

    
    
}
