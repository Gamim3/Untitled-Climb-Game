using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCorrectWall : MonoBehaviour
{
    public Transform Body;
    public Vector3 point;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Point"))
        {
            point = other.transform.position;
            Body.LookAt(point);
        }
    }
}
