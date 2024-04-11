using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropeSwing : MonoBehaviour
{
    public GravityWhileClimbing gravityWhileClimbing;
    public GameObject player;
    public GameObject attachPoint;

    bool newbool;
    Vector3 avghandpos;
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
            /*if(newbool == true)
            {
                avghandpos = player.GetComponent<Zipline>().avgHandPos.position - gameObject.transform.position;
                newbool = false;
            }
            */
            Vector3 posdif = player.GetComponent<Zipline>().avgHandPos.position - player.transform.position;
            player.transform.position = gravityWhileClimbing.swing.transform.position - posdif + avghandpos;
        }
        else
        {
            newbool = true;
        }
        
    }
}
