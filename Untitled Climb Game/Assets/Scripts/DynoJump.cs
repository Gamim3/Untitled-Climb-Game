using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class DynoJump : MonoBehaviour
{
    // public Transform playerBody;
    public Stamina stamina;
    public Transform playerHandR;
    public Transform playerHandL;
    public Transform playerBody;
    public Transform playerRotationPoint;
    public Transform averageHandPosition;
    public Transform averageTestRot;
    public float averageHandRotationPoint;
    public Vector3 averageHandRotation;

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
    public InputActionProperty rotationPropertyR;
    public InputActionProperty rotationPropertyL;
    public Vector3 velocityR;
    public Vector3 velocityL;
    public Vector3 rotationL;
    public Vector3 rotationR;
    public Vector3 rotationAv;
    public Vector3 velocityAv;
    public Vector3 startJumpPosition;
    public Vector3 jumpDirection;
    public Vector3 endJumpPoint;
    public Vector3 playerbodyRotation;
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
        playerBody.transform.LookAt(averageHandPosition);
        handPositionR = playerHandR.position;
        handPositionL = playerHandL.position;
        bodyPosition = playerBody.position;

        averageHand = (handPositionL + handPositionR) / 2;
        rotationAv.y = (playerHandR.localRotation.y + playerHandL.localRotation.y) / 2;
      
        averageHandPosition.position = averageHand;
        velocityL = velocityPropertyR.action.ReadValue<Vector3>();
        velocityR = velocityPropertyL.action.ReadValue<Vector3>();

        velocityAv.x = (velocityR.x + velocityL.x) / 2;
        velocityAv.y = (velocityR.y + velocityL.y) / 2;
        playerbodyRotation = new Vector3(playerRotationPoint.localRotation.x, playerRotationPoint.localRotation.y, playerRotationPoint.localRotation.z) ;
        jumpDirection = new Vector3(velocityAv.x * 1.5f , velocityAv.y, 0);

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
            jumpCooldown = 0f;
        }
        UseGravity();
        
       
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
            
                if (velocityAv.y <=-2f)
                {

                    if (rightSelectValue.action.ReadValue<float>() <= 0.1f && leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
                    {
                        //rb.velocity = new Vector3(0, -rb.velocity.y * 2, 0);\
                        Vector3 direction = new Vector3(playerBody.transform.position.x, rb.transform.position.y, 0);
                        float velocity = (velocityAv.y + velocityAv.x) / 2;
                        Vector3 force = direction.normalized * velocity;
                        rb.AddRelativeForce(force,ForceMode.Impulse) ;
                        startTimer = true;
                        startJumpCooldown = true;
                        jumped = true;
                        stamina.currentStamina -= 10f;
                        Debug.LogWarning("DynoJump:)");

                    }
                }
        }
    }
   
    public void UseGravity()
    {
        if (timer <= 0)
        {
            startTimer = false;
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
