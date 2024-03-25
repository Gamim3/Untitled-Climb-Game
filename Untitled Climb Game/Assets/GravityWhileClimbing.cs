using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
public class GravityWhileClimbing : MonoBehaviour
{
    public bool isAttachedL, isAttachedR;
    public AudioSource audioSourceL,audioSourceR;
    public AudioClip handsClip;
    public DynoJump dynojump;
    public bool rHand;
    public bool lHand;
    public bool ziplineInHand;
    public bool ropeInHand;
    public bool ziplineinBothHands;
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
            audioSourceL.PlayOneShot(handsClip);
            isAttachedL = true;

        }
        else if (other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)
        {
            audioSourceL.PlayOneShot(handsClip);
            isAttachedR = true;
        }
      
        if (other.CompareTag("Rock") && leftSelectvalue.action.ReadValue<float>() > 0.1f || other.CompareTag("Rock") && rightSelectvalue.action.ReadValue<float>() > 0.1f)
        {

            dynojump.onWall = true;
        }
        if (other.CompareTag("Zipline") && leftSelectvalue.action.ReadValue<float>() > 0.1f || (other.CompareTag("Zipline") && rightSelectvalue.action.ReadValue<float>() > 0.1f))
        {
            ziplineInHand = true;
        }
        else
        {
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
        }
        else
        {
            ropeInHand = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isAttachedL = false;
        isAttachedR = false;
        dynojump.onWall = false;
    }



}
