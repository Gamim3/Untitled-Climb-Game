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
    public GameObject fakeHandR;
    public GameObject fakeHandL;
    public GameObject realHandL;
    public GameObject realHandR;
    public GameObject playerCam;
    public Rigidbody body;
    public GameObject originalPlayer;

    public InputActionProperty leftSelectvalue;
    public InputActionProperty rightSelectvalue;


    // Start is called before the first frame update
    void Start()
    {
        goToPoint = endpoint.transform.position;
    }
  

    // Update is called once per frame
    void Update()
    {
        zipHandle = handle.transform.position;
        Zipping();
        PlayerColliderFix();
    }
    public void Zipping()
    {
        if(gravityWhileClimbing.ziplineInHand)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
            //player.transform.SetParent(handle.transform);
            FollowPosition();
            hasHandle = true;
        }
        else
        {
            
           // player.transform.SetParent(originalPlayer.transform);
            hasHandle = false;
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        print("rightHand");
        
        if (other.tag == "RightHand")
        {
            print("rightHand");
            realHandL.GetComponent<SkinnedMeshRenderer>().enabled = false;
            realHandR.GetComponent<SkinnedMeshRenderer>().enabled = false;
            fakeHandR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            fakeHandL.GetComponent<SkinnedMeshRenderer>().enabled = true;
           
        }
        else
        {
            realHandR.GetComponent<SkinnedMeshRenderer>().enabled = true;
            realHandL.GetComponent<SkinnedMeshRenderer>().enabled = true;
            fakeHandR.GetComponent<SkinnedMeshRenderer>().enabled = false;
            fakeHandL.GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }
    
    public void FollowPosition()
    {
        player.transform.position = attachPoint.transform.position;
        player.transform.rotation = attachPoint.transform.rotation;
        //print(player.transform.position);
    }
   
    public void PlayerColliderFix()
    {
        player.GetComponent<CapsuleCollider>().center = playerCam.transform.position;
    }
}
