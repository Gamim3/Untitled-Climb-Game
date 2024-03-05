using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zipline : MonoBehaviour
{
    public GravityWhileClimbing gravityWhileClimbing;
    public Vector3 goToPoint;
    public Vector3 zipHandle;
    public Transform attachPoint;
    public float speed;
    public float step;
    public bool hasHandle;
    public GameObject handle;
    public GameObject endpoint;
    public GameObject player;
    public GameObject righthandPosition;
    public GameObject lefthandPosition;
    public Rigidbody body;
    public GameObject originalPlayer;

    public InputActionProperty leftSelectvalue;
    public InputActionProperty rightSelectvalue;


    // Start is called before the first frame update
    void Start()
    {
        goToPoint = endpoint.transform.position;
    }
    public void FixedUpdate()
    {
        if(hasHandle)
        {
            player.transform.position = attachPoint.position;
        }
        else
        {
            player.transform.position = player.transform.position;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        zipHandle = handle.transform.position;
        Zipping();
    }
    public void Zipping()
    {
        if(gravityWhileClimbing.ziplineInHand)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
            player.transform.SetParent(handle.transform);

            hasHandle = true;
        }
        else
        {
            
            player.transform.SetParent(originalPlayer.transform);
            hasHandle= false;
            
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "LeftHand")
        {
            gravityWhileClimbing.leftHand.transform.position = lefthandPosition.transform.position;
        }
        if (collision.collider.tag == "RightHand")
        {
            gravityWhileClimbing.rightHand.transform.position = righthandPosition.transform.position;
        }
        else if (collision.collider.tag == null)
        {
            gravityWhileClimbing.rightHand.transform.position = gravityWhileClimbing.rightHand.transform.position;
            gravityWhileClimbing.leftHand.transform.position = gravityWhileClimbing.leftHand.transform.position;
        }
    }
   

}
