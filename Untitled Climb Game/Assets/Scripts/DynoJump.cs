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
    public float averageHand;
    public Vector3 rigidbodyVelocity;
    public Vector3 currentPosition;
    public Vector3 lastPosition;
  
    public InputActionProperty leftSelectValue;
    public InputActionProperty rightSelectValue;
    public InputActionProperty rightTriggerValue;
    public InputActionProperty leftTriggerValue;

    public InputActionProperty rightPressUiValue;
    // Start is called before the first frame update
    void Start()
    {
        timer = 1.2f;
        jumpCooldown = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        TestJump();
        
        UseGravity();
        handPositionR.y = playerHandR.position.y;
        handPositionL.y = playerHandL.position.y;
        bodyPosition = playerBody.position;

        averageHand = (handPositionL.y + handPositionR.y) / 2;
        //Debug.Log(averageHand);
    }
   

    public void TestJump()
    {
        if (onWall)
        {
            if (averageHand <= bodyPosition.y)
            {
                rigidbodyVelocity = new Vector3(rb.velocity.x, - rb.velocity.y, 0f);
                float averageVelocity =  rigidbodyVelocity.magnitude;
                print(averageVelocity);
                if (rightSelectValue.action.ReadValue<float>() <= 0.1f && leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
                {
                    preJumpPosition = player.transform.position;
                    rb.GetComponent<Rigidbody>().useGravity = false;
                    rb.AddForce(rigidbodyVelocity * 0.75f ,ForceMode.Impulse);
                    player.GetComponent<CapsuleCollider>().enabled = false;
                    startTimer = true;
                    startJumpCooldown = true;
                    jumped = true;
                    Debug.Log("DynoJump:)");
                    //player.GetComponent<CapsuleCollider>().enabled = false;


                }
            }
            
        }
    }
   
    public void UseGravity()
    {
        if (timer <= 0)
        {
            rb.GetComponent<Rigidbody>().useGravity = true;
            startTimer = false;
            player.GetComponent<CapsuleCollider>().enabled = true;
            

        }
        if(jumpCooldown <= 0)
        {
            jumped = false;
            startJumpCooldown = false;
        }
    }
}
