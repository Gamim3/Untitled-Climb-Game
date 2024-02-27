using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DynoJump : MonoBehaviour
{
   // public Transform playerBody;
    public Transform playerHandR;
    public Transform playerHandL;
    public Transform playerBody;

    public Vector3 handPosition;
    public Vector3 bodyPosition;
    

    public bool jumpIsReady;
    public bool onWall = false;
    public bool jumped = false;

    public GameObject player;

    public Rigidbody rb;
    public float speed;
    public Vector3 rigidbodyVelocity;
  
    public InputActionProperty leftSelectValue;
    public InputActionProperty rightSelectValue;

    public InputActionProperty rightPressUiValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        handPosition = playerHandR.position;
        bodyPosition = playerBody.position;
        if (onWall == true && handPosition.y <= bodyPosition.y)
        {
            TestJump();
            Debug.Log("Test");
        }

        rigidbodyVelocity = (rb.velocity * speed)  *-1 * Time.deltaTime;

       /* currentPosition = playerHandL.position;
        if (currentPosition != lastPosition)
        {
            
            if (leftSelectValue.action.ReadValue<float>() >= 0.1 || rightSelectValue.action.ReadValue<float>() >= 0.1)
            {
                jumpIsReady = true;
               
            }
            else
            {
                jumpIsReady= false;
            }
            
            
        }

        JumpReady();

        //AddVelocity();
        // CheckHands();
       */
    }
   /* private void LateUpdate()
    {
        lastPosition = currentPosition;

    }

    
    public void AddVelocity()
    {
 
        rb.AddForce(rigidbodyVelocity, ForceMode.Impulse);
    }
    public void JumpReady()
    {
        if (jumpIsReady == false)
        {
            AddVelocity();
        }
    }
   */

    public void TestJump()
    {
        if (rightSelectValue.action.ReadValue<float>() <= 0.1f || leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
        {
            rb.AddForce(rigidbodyVelocity, ForceMode.Impulse);
            Debug.Log("IKBENKLAAR");
            player.GetComponent<CapsuleCollider>().enabled = false;
            jumped = true;
        }
        else
        {
            player.GetComponent<CapsuleCollider>().enabled = true;
            jumped = false;
        }
    }
}
