using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DynoJump2 : MonoBehaviour
{
    public List<Vector3> positionsL, positionsR;

    public Vector3 handL, handR;
    public Vector3 averageL, averageR;
    public Vector3 totalL, totalR;
    public GameObject lHand, rHand;
    public int maxCount;
    public Vector3 trashHold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FillPositions());
        Calculator();
    }
    public IEnumerator FillPositions()
    {
        handL = lHand.transform.position;
        handR = rHand.transform.position;
        positionsL.Add(handL);
        positionsR.Add(handR);
        if(positionsL.Count > maxCount)
        {
            positionsL.RemoveAt(0);
        }
        if (positionsR.Count > maxCount)
        {
            positionsR.RemoveAt(0);
        }
        yield return 1f;
    }
    public void Calculator()
    {
        totalL = positionsL[0] + positionsL[1] + positionsL[2] + positionsL[3] + positionsL[4];
        totalR = positionsR[0] + positionsR[1] + positionsR[2] + positionsR[3] + positionsR[4];
        averageL = totalL / maxCount;
        averageR = totalR / maxCount;
        
    }
    public void ReachedTrashhold()
    {
        
    }
}
