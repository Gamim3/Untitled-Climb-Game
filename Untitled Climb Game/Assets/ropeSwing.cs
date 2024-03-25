using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeSwing : MonoBehaviour
{
    public GravityWhileClimbing gravityWhileClimbing;
    public GameObject player;
    public GameObject cube;
    public Rigidbody rb;
    public GameObject rope;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gravityWhileClimbing.ropeInHand)
        {
            player.transform.position = rope.transform.position;
            rb.isKinematic = false;
        }
        else
        {
            player.transform.position = player.transform.position;
        }
       
    }
}
