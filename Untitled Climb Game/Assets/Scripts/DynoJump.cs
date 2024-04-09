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
        jumpCooldown = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //playerBody.transform.LookAt();
        velocityL = velocityPropertyR.action.ReadValue<Vector3>();
        velocityR = velocityPropertyL.action.ReadValue<Vector3>();

        velocityAv.x = (velocityR.x + velocityL.x) / 2;
        velocityAv.y = (velocityR.y + velocityL.y) / 2;


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

            if (velocityAv.y <= -1f)
            {
                if (rightSelectValue.action.ReadValue<float>() <= 0.1f && leftSelectValue.action.ReadValue<float>() <= 0.1f && jumped == false)
                {
                    //rb.velocity = new Vector3(0, -rb.velocity.y * 2, 0);\
                    jumped = true;
                    Vector3 direction = new Vector3(0, - playerBody.transform.position.y, 0);
                    float velocity = velocityAv.y;
                    Vector3 force = direction.normalized * velocity; 
                    jump = new Vector3(0,8,0);
                    rb.AddRelativeForce(jump, ForceMode.Impulse);
                    startTimer = true;
                    startJumpCooldown = true;
                    
                    stamina.currentStamina -= 10f;
                    Debug.LogWarning("DynoJump:)");

                }
            }
        }
        

        
    }
    private void UseGravity()
    {
        if (timer <= 0)
        {
            startTimer = false;
            rb.constraints = RigidbodyConstraints.None;
            rb.constraints = RigidbodyConstraints.FreezeRotation;

        }
        if (jumpCooldown <= 0)
        {
            jumped = false;
            startJumpCooldown = false;
        }
    }
}
