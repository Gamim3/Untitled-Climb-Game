using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AirballoonPAth : MonoBehaviour
{ 
    public Transform[] pathPos;
    public Transform playerMayNotMove;
    public Transform player;
    public int indexForArray;
    public float speed;
    
    public bool readyToFly;

 // Start is called before the first frame update
    void Start()
    {
        // set bool to false so balloon wont go rogue!
        readyToFly = false;   
        indexForArray =0;
    }

 // Update is called once per frame
    void Update()
    {
       //if balloon is ready to fly by checking in the ontriggerEnter, Fly to the index of the array
        if(readyToFly)
        {
           transform.position= Vector3.MoveTowards(transform.position,pathPos[indexForArray].position,speed);
           GoToNextInArray();
        }
     
    }
    // is player in on trigger 
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            player.SetParent(playerMayNotMove);
            readyToFly = true;
        }
     
    }
    
    // goes to next point in array.
     public void GoToNextInArray()
    {
           if(transform.position == pathPos[indexForArray].position)
            {
                indexForArray +=1;
            
            }
            else
            {
                player.transform.position = player.transform.position;
                indexForArray +=0;
                player.SetParent(null);

            }
       
        
        
       

    }
}
