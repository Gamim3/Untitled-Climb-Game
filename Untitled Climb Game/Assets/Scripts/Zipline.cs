using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zipline : MonoBehaviour
{
    public GravityWhileClimbing GravityWhileClimbing;
    public Vector3 goToPoint;
    public Vector3 zipHandle;
    public Transform attachPoint;
    public float speed;
    public float step;
    public GameObject handle;
    public GameObject endpoint;
    public GameObject player;
    public Rigidbody body;


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
    }
    public void Zipping()
    {
        if(GravityWhileClimbing.ziplineInHand)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(zipHandle, goToPoint, step);
            player.transform.SetParent(handle.transform);
            
            FollowHandle();
        }
        else
        {
            
            player.transform.SetParent(null);
            
        }
    }
    public void FollowHandle()
    {
        player.transform.position = attachPoint.position;
    }
}
