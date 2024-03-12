using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DynoJump : MonoBehaviour
{
   // public Transform playerBody;
    public Transform playerHandR;
    public Transform playerHandL;
    public Transform playerBody;

    public Vector3 handPositionL;
    public Vector3 handPositionR;
    public Vector3 bodyPosition;
    public Vector3 playerPosition;
    public Vector3 preJumpPosition;
    

    public bool startTimer;
    public bool startJumpCooldown;
    public bool onWall = false;
    public bool jumped = false;

    public GameObject player;

    public Rigidbody rb;
    public float speed;
    public float timer;
    public float jumpCooldown;
    public float playerRotation;
    public Vector3 avarageDirection;
    public Vector3 averageHand;
    public Vector3 rigidbodyVelocity;
    public Vector3 currentPosition;
    public Vector3 lastPosition;
    public Vector3 jump;
    public Vector3 directionY;
    public Vector3 directionX;
    public InputActionProperty leftSelectValue;
    public InputActionProperty rightSelectValue;
    public InputActionProperty rightTriggerValue;
    public InputActionProperty leftTriggerValue;

    public InputActionProperty velocityPropertyR;
    public InputActionProperty velocityPropertyL;
    public Vector3 velocityR;
    public Vector3 velocityL;
    public Vector3 velocityAv;
    public InputActionProperty rightPressUiValue;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.2f;
        jumpCooldown = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        velocityL = velocityPropertyR.action.ReadValue<Vector3>();
        velocityR = velocityPropertyL.action.ReadValue<Vector3>();
        velocityAv.x = (velocityR.x + velocityL.x) / 2;
        velocityAv.y = (velocityR.y + velocityL.y) / 2;
        Debug.Log(velocityAv);
        //transform.localPosition = Quaternion.Euler(playerBody.position.x, playerBody.position.y,playerBody.position.z);
        jump = ((playerBody.transform.up * -rb.velocity.y + playerBody.transform.right * -rb.velocity.x + playerBody.transform.forward * -rb.velocity.z));
        directionY = new Vector3(0, jump.y, 0);
        directionX = new Vector3(jump.x, 0, jump.z);

        avarageDirection = (directionX + directionY);
        
        if (startTimer)
        {
            timer -= Time.deltaTime;
            
        }
        if (startJumpCooldown)
        {
            jumpCooldown -= Time.deltaTime;
        }
        else
        {
            timer = 1.2f;
            jumpCooldown = 4f;
        }
    
        //rigidbodyVelocity = new Vector3(rb.velocity.x * 50, -rb.velocity.y, 0f);
        UseGravity();
        handPositionR = playerHandR.position;
        handPositionL = playerHandL.position;
        bodyPosition = playerBody.position;

        averageHand = (handPositionL + handPositionR) / 2;
        //Debug.Log(averageHand);
    }

    public void FixedUpdate()
    {
        TestJump();
    }
    public void TestJump()
    {
        if (onWall)
        {
           // Vector3 floris = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
            if (averageHand.y <= bodyPosition.y)
            {
               // Debug.Log(rb.velocity.x);
              //  float averageVelocity =  rigidbodyVelocity.magnitude;
                if (rightSelectValue.action.ReadValue<float>() <= 0.1f && leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
                {
                    player.GetComponent<CapsuleCollider>().enabled = false;
                    rb.GetComponent<Rigidbody>().useGravity = false;
                    rb.constraints = RigidbodyConstraints.FreezePositionZ;
                    //rb.velocity = -rb.velocity * 2;
                    rb.AddRelativeForce(new Vector3(-velocityAv.x *2, - velocityAv.y,0),ForceMode.Impulse);
                    //rb.AddRelativeForce(-directionX * 0.75f, ForceMode.VelocityChange);
                    startTimer = true;
                    startJumpCooldown = true;
                    jumped = true;
                    Debug.Log("DynoJump:)");


                }
            }
            //if(averageHand.x >= bodyPosition.x)
            //{
            //    if (rightSelectValue.action.ReadValue<float>() <= 0.1f && leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
            //    {
            //        rb.AddRelativeForce(new Vector3(-floris.x, 0, -floris.z) * 100f, ForceMode.VelocityChange);
            //        Debug.LogError("sideJumpRoel!");
            //        jumped = true;
            //        startTimer = true;
            //        startJumpCooldown = true;
            //    }
            //}
            //if (averageHand.x <= bodyPosition.x)
            //{
            //    if (rightSelectValue.action.ReadValue<float>() <= 0.1f && leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
            //    {
            //        rb.AddRelativeForce(new Vector3(floris.x, 0, floris.z) * 100f, ForceMode.VelocityChange);
            //        Debug.LogError("sideJumpJelmer!");
            //        jumped = true;
            //        startTimer = true;
            //        startJumpCooldown = true;
            //    }
            //}

        }
    }
   
    public void UseGravity()
    {
        if (timer <= 0)
        {
            rb.GetComponent<Rigidbody>().useGravity = true;
            
            startTimer = false;
            player.GetComponent<CapsuleCollider>().enabled = true;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
        if(jumpCooldown <= 0)
        {
            jumped = false;
            startJumpCooldown = false;
        }
    }
}
