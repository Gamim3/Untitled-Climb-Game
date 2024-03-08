using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AirballoonPAth : MonoBehaviour
{ 
    public Transform pathPos;
    public float speed;
    public bool readyToFly;

 // Start is called before the first frame update
    void Start()
    {
        readyToFly = false;   
    }

 // Update is called once per frame
    void Update()
    {
       transform.position= Vector3.MoveTowards(transform.position,pathPos.position,speed);
        if(readyToFly)
        {
           
           
        }
     
    }
    public void OnTriggerEnter(Collider other)
    {
        readyToFly = true;
    }
}
