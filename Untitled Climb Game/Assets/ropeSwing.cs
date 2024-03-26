using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeSwing : MonoBehaviour
{
    public GravityWhileClimbing gravityWhileClimbing;
    public GameObject player;
    public GameObject playerHandR;
    public GameObject playerHandL;
    public GameObject cube;
    public Transform rightAttach;
    public Transform leftAttach;
    public Rigidbody rb;
    public GameObject rope;
    public bool forceOff;
    public float timertje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandEnter();


    }
   
    public void HandEnter()
    {
        if (gravityWhileClimbing.ropeInHand)
        {
            player.transform.position = rope.transform.position;
        }
        
    }
}
