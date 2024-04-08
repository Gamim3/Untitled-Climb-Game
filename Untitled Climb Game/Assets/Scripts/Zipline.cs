using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Zipline : MonoBehaviour
{
    public AudioSource zipLineSoundManager;
    public AudioClip zipping;
    public GravityWhileClimbing gravityWhileClimbing;
    public Stamina stamina;
    public index uitdex;
    public Vector3 goToPoint;
    public Vector3 zipHandle;
    public Transform attachPoint;
    public Transform[] beginPoint;
    public float speed;
    public float step;
    public int uitdexDoorgeven;
    public bool hasHandle;
    public GameObject handle;
    public GameObject[] endpoint;
    public GameObject player;
    public Transform righthandPosition;
    public Transform lefthandPosition;
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
        
        
        goToPoint = endpoint[gravityWhileClimbing.number].transform.position;
        zipHandle = gravityWhileClimbing.handle.transform.position;
        attachPoint = gravityWhileClimbing.attachPoint;

        step = speed * Time.deltaTime;
            
        //player.transform.SetParent(handle.transform.GetChild(0));
            
        hasHandle = true;

        if (gravityWhileClimbing.ziplineinBothHands)
        {
            zipLineSoundManager.enabled = true;
            FollowPosition();
            gravityWhileClimbing.handle.transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
        }
        
        else
        {
            zipLineSoundManager.enabled = false;
            hasHandle = false;
            //player.transform.SetParent(null);
            gravityWhileClimbing.handle.transform.position = Vector3.MoveTowards(zipHandle, beginPoint[gravityWhileClimbing.number].position, step);

        }
        /*
        if(gravityWhileClimbing.name == "ZipLine1")
         {
            goToPoint = endpoint.transform.position;
            zipHandle = gravityWhileClimbing.handle.transform.position;
            step = speed * Time.deltaTime;
            
           // player.transform.SetParent(handle[1].transform.GetChild(0));
            
            hasHandle = true;
            if (gravityWhileClimbing.ziplineinBothHands)
            {
                FollowPosition();
                gravityWhileClimbing.handle.transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
                

            }
        }
        else if (hasHandle)
        {
            
            hasHandle = false;
            //player.transform.SetParent(null);
            gravityWhileClimbing.handle.transform.position = Vector3.MoveTowards(zipHandle, beginPoint[1].position, step);

        }
        */
        
    }
    
    public void FollowPosition()
    {
        Debug.Log("pijn is fijn");
        player.transform.position = gravityWhileClimbing.attachPoint.position;
        /*
       else if(gravityWhileClimbing.name == "ZipLine1")
        {
            player.transform.position = gravityWhileClimbing.attachPoint.position;
            
        }
        */
    }
        
    
}
