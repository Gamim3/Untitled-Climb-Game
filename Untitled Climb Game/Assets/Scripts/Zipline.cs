using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zipline : MonoBehaviour
{
    public GravityWhileClimbing gravityWhileClimbing;
    public Stamina stamina;
    public Vector3 goToPoint;
    public Vector3 zipHandle;
    public Transform attachPoint;
    public Transform beginPoint;
    public float speed;
    public float step;
    public bool hasHandle;
    public GameObject handle;
    public GameObject[] endpoint;
    public GameObject player;
   // public GameObject righthandPosition;
   // public GameObject lefthandPosition;
   // public GameObject fakeHandR;
   // public GameObject fakeHandL;
   // public GameObject realHandL;
   // public GameObject realHandR; 
    public Rigidbody body;
    //public GameObject originalPlayer;

    public InputActionProperty leftSelectvalue;
    public InputActionProperty rightSelectvalue;


    // Start is called before the first frame update
    void Start()
    {
        goToPoint = endpoint[0].transform.position;
    }
  

    // Update is called once per frame
    void Update()
    {
        zipHandle = handle.transform.position;
        Zipping();
       // PlayerColliderFix();
    }
    public void Zipping()
    {
        if(gravityWhileClimbing.ziplineInHand)
        {
            step = speed * Time.deltaTime;
            
            player.transform.SetParent(attachPoint);
            
            hasHandle = true;
            if (gravityWhileClimbing.ziplineinBothHands)
            {
                FollowPosition();
                transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
                

            }
        }
        else
        {
            
            hasHandle = false;
            player.transform.SetParent(null);
            transform.position = Vector3.MoveTowards(zipHandle, beginPoint.position, step);

        }
    }
    
    public void FollowPosition()
    {
        player.transform.position = attachPoint.transform.position;
        //player.transform.rotation = attachPoint.transform.rotation;
        //print(player.transform.position);
    }
    
}
