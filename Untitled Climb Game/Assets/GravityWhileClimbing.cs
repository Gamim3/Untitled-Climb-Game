using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
public class GravityWhileClimbing : MonoBehaviour
{
    public bool isAttachedL, isAttachedR;
    public new string name;

    public AudioSource audioSourceL,audioSourceR;
    public AudioClip handsClip;
    public DynoJump dynojump;
    public ropeSwing ropeSwing;
    public Transform rightAttach;
    public Transform lefttAttach;
    public bool rHand;
    public bool lHand;
    public bool ziplineInHand;
    public bool ropeInHand;
    public bool ziplineinBothHands;
    public bool hasPlayedL;
    public bool hasPlayedR;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject moveProvider;
    public GameObject playerRotatePoint;
    //public XRDirectInteractor leftDirectGrab;
    //public XRDirectInteractor rightDirectGrab;
    public InputActionProperty leftSelectvalue;
    public InputActionProperty rightSelectvalue;

    public void Start()
    {
        dynojump.onWall = false;
    }
    // Update is called once per frame
    void Update()
    {
        //GrabSound();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
           //lookat.useUpObject = other.transform;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f)

        {
            
            isAttachedL = true;

        }
        else if (other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)
        {
            
            isAttachedR = true;
        }
        
      
        if (other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f || other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)
        {

            dynojump.onWall = true;
        }
        if (other.CompareTag("Zipline") && leftSelectvalue.action.ReadValue<float>() > 0.1f || (other.CompareTag("Zipline") && rightSelectvalue.action.ReadValue<float>() > 0.1f))
        {
            name = other.name;
            ziplineInHand = true;
        }
        else
        {
            name = null;
            ziplineInHand = false;
        }
        if (other.CompareTag("Zipline") && leftSelectvalue.action.ReadValue<float>() > 0.1f && (other.CompareTag("Zipline") && rightSelectvalue.action.ReadValue<float>() > 0.1f))
        {
            ziplineinBothHands = true;
        }
        else
        {
            ziplineinBothHands = false;
        }
        if (other.CompareTag("RopeSwing") && leftSelectvalue.action.ReadValue<float>() > 0.1f || (other.CompareTag("RopeSwing") && rightSelectvalue.action.ReadValue<float>() > 0.1f))
        {
            ropeInHand = true;
            ropeSwing.GetComponent<Rigidbody>().isKinematic = false;
        }
        else if (leftSelectvalue.action.ReadValue<float>() < 0.1f && rightSelectvalue.action.ReadValue<float>() < 0.1f)
        {
            ropeInHand = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAttachedL = false;
        isAttachedR = false;
        dynojump.onWall = false;
        hasPlayedL = false;
        hasPlayedR = false;
        //ropeInHand = false;
    }

   



}
