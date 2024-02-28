using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DynoJump : MonoBehaviour
{
   // public Transform playerBody;
    public Transform playerHandR;
    public Transform playerHandL;
    public Transform playerBody;

    public Vector3 handPosition;
    public Vector3 bodyPosition;
    public Vector3 playerPosition;
    public Vector3 preJumpPosition;
    

    public bool jumpIsReady;
    public bool startTimer;
    public bool onWall = false;
    public bool jumped = false;

    public GameObject player;

    public Rigidbody rb;
    public float speed;
    public float timer;
    public Vector3 rigidbodyVelocity;
  
    public InputActionProperty leftSelectValue;
    public InputActionProperty rightSelectValue;

    public InputActionProperty rightPressUiValue;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (startTimer)
        {
           timer -= Time.deltaTime;
        }
        else if (!startTimer)
        {
            timer = 1.5f;
        }
        TestJump();
        
        UseGravity();
        handPosition = playerHandR.position;
        bodyPosition = playerBody.position;
        

        rigidbodyVelocity =- (rb.velocity * speed) * Time.deltaTime;

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
        if (onWall)
        {


            if (rightSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false || leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
            {
                jumped = true;
                preJumpPosition = player.transform.position;
                rb.GetComponent<Rigidbody>().useGravity = false;
                startTimer = true;
                rb.AddForce(rigidbodyVelocity * 5 , ForceMode.Impulse);
                Debug.Log("DynoJump:)");
                //player.GetComponent<CapsuleCollider>().enabled = false;

                
            }
        }
    }
   
    public void UseGravity()
    {
        if (timer <= 0)
        {
            jumped = false;
            rb.GetComponent<Rigidbody>().useGravity = true;
            startTimer = false;
        }
    }
}
