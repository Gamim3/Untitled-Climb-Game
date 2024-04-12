using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject canvas;
    public bool hasFinished;
    public float time = 100f;

    public void ResetScene ()
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
        
            canvas.SetActive(true);
            hasFinished = true;
        }
    }
    void Update()
    {
     if(hasFinished)
     {
        time -= Time.deltaTime;
        if(time <= 0)
        {
            ResetScene();
        }
     }
    }

    
}
