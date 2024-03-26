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
    public Transform[] beginPoint;
    public float speed;
    public float step;
    public bool hasHandle;
    public GameObject[] handle;
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
        
    }
  

    // Update is called once per frame
    void Update()
    {
       // zipHandle = handle.transform.position;
        Zipping();
       // PlayerColliderFix();
    }
    public void Zipping()
    {
        if(gravityWhileClimbing.name == "ZipLine0")
        {
            goToPoint = endpoint[0].transform.position;
            zipHandle = handle[0].transform.position;

            step = speed * Time.deltaTime;
            
            //player.transform.SetParent(handle[0].transform.GetChild(0));
            
            hasHandle = true;
            if (gravityWhileClimbing.ziplineinBothHands)
            {
                FollowPosition();
                transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
                

            }
        }
        else if (hasHandle)
        {
            
            hasHandle = false;
            //player.transform.SetParent(null);
            transform.position = Vector3.MoveTowards(zipHandle, beginPoint[0].position, step);

        }
    /*
        if(gravityWhileClimbing.name == "ZipLine1")
         {
            goToPoint = endpoint[1].transform.position;
            zipHandle = handle[1].transform.position;
            step = speed * Time.deltaTime;
            
           // player.transform.SetParent(handle[1].transform.GetChild(0));
            
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
            //player.transform.SetParent(null);
            transform.position = Vector3.MoveTowards(zipHandle, beginPoint[1].position, step);

        }
        */
    }
    
    public void FollowPosition()
    {
        if(gravityWhileClimbing.name == "ZipLine0")
        {
            player.transform.position = handle[0].transform.GetChild(0).position;

        }
       /* else if(gravityWhileClimbing.name == "ZipLine1")
        {
            player.transform.position = handle[1].transform.GetChild(0).position;
            
        }
        */
       

        //player.transform.rotation = attachPoint.transform.rotation;
        //print(player.transform.position);
    }
    
}
