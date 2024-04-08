using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AirballoonPAth : MonoBehaviour
{
    public AudioSource playSound;
    
    public Transform startPoint;
    public Transform[] pathPos;
    public Transform playerMayNotMove;
    public Transform player;
    public int indexForArray;
    public float speed;
    public float timer = 5f, returnTimer = 40f;
    
    public bool readyToFly;
    public bool playerInBalloon;
    public bool lastCheckpoint =false;
    

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
        
        if(timer <= 0)
        {
            if (readyToFly)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathPos[indexForArray].position, speed);
                transform.rotation = Quaternion.Slerp(transform.rotation, pathPos[3].rotation, speed);
                GoToNextInArray();
                 playSound.enabled = true;
            }
            if (pathPos[indexForArray] == pathPos[3])
            {
                
                playSound.enabled = false;
                lastCheckpoint = true;
                returnTimer -= Time.deltaTime;
                if(returnTimer <= 0)
                {
                    transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed);
                }
                
            }
        }
        
     
    }
    // is player in on trigger 
    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {

            player.transform.position = playerMayNotMove.transform.position;
            readyToFly = true;
            timer -= Time.deltaTime;
            playerInBalloon = true;
        }
       
     
    }
    public void OnTriggerExit(Collider other)
    {
        readyToFly = false;
        playerInBalloon = false;
    }

    // goes to next point in array.
    public void GoToNextInArray()
    {
           if(transform.position == pathPos[indexForArray].position && !lastCheckpoint)
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
