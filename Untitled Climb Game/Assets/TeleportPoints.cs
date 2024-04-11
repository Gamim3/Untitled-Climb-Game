using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TeleportPoints : MonoBehaviour
{
    public Transform[] teleportPoints;
    public int index;
    public float timer = 0.5f;
    public int indexMax;
    public bool pressed;
    public InputActionProperty TeleportL;
    public InputActionProperty TeleportR;
    // Start is called before the first frame update
    void Start()
    {
        TeleportL.action.started += OnTeleportL;
        TeleportR.action.started += OnTeleportR;
    }
    private void Update()
    {
        if(index < 0)
        {
            index = 3;
        }
        if(index >= 4)
        {
            index = 0;
        }
    }
    void OnTeleportL(InputAction.CallbackContext context)
    {
        Teleporten();
    }
    
    void OnTeleportR(InputAction.CallbackContext context)
    {
        Teleporten();
    }
   

    public void Teleporten()
    {
        if (TeleportL.action.ReadValue<float>() >= 0.1f)
        {
            index--;
            if (index < 0)
            {
                index = 3;
            }

            transform.position = teleportPoints[index].position;
            pressed = false;
            timer = 2;
        }
        if (TeleportR.action.ReadValue<float>() >= 0.1f)
        {
            index++;
            if (index > 3)
            {
                index = 0;
            }

            transform.position = teleportPoints[index].position;
            pressed = false;
            timer = 2;
        }
    }
}
