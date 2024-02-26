using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class GravityWhileClimbing : MonoBehaviour
{
    public bool isAttached;
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
        EnableGravity();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f || rightSelectvalue.action.ReadValue<float>() > 0.1f)
            
        {
            isAttached = true;
            
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        isAttached = false; 
    }

    private void EnableGravity()
    {
        if (isAttached)
        {
           //moveProvider.GetComponent<CharacterController>().enabled = false;
        }
        else
        {
            //moveProvider.GetComponent<CharacterController>().enabled = true;
        }
    }
}
