using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class TestActionController : MonoBehaviour
{
    private ActionBasedController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        bool isPressed = controller.selectAction.action.ReadValue<bool>();

        controller.selectAction.action.performed += Action_Performed;

    }

    private void Action_Performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Select Button is Pressed");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
