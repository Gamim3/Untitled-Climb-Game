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

    public Vector3 handPositionL;
    public Vector3 handPositionR;
    public Vector3 bodyPosition;
    public Vector3 playerPosition;
    public Vector3 preJumpPosition;
    

    public bool startTimer;
    public bool onWall = false;
    public bool jumped = false;

    public GameObject player;

    public Rigidbody rb;
    public float speed;
    public float timer;
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
        timer = 1f;
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
            timer = 1f;
        }
        TestJump();
        
        UseGravity();
        handPositionR = playerHandR.position;
        handPositionL = playerHandL.position;
        bodyPosition = playerBody.position;
        

        rigidbodyVelocity =- (rb.velocity * speed) * Time.deltaTime;
        if (bodyPosition.y <= handPositionR.y && bodyPosition.y <= handPositionL.y)
        {
            jumped = false;
        }
    }
   

    public void TestJump()
    {
        if (onWall)
        {
            print(handPositionR - bodyPosition);
            print(handPositionL - bodyPosition);
            if (handPositionR.y <= bodyPosition.y && handPositionL.y <= bodyPosition.y)
            {
                if (rightSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false || leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
                {
                    preJumpPosition = player.transform.position;
                    rb.GetComponent<Rigidbody>().useGravity = false;
                    rb.AddForce(rigidbodyVelocity * 1.75f, ForceMode.Impulse);
                    player.GetComponent<CapsuleCollider>().enabled = false;
                    startTimer = true;
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
    }
}
