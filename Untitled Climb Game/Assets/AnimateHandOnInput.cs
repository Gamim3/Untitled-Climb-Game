using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandOnInput : MonoBehaviour

{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public InputActionProperty thumbTouch;
    public Animator handAnimator;
    public GameObject _Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "HandL" && _Player.GetComponent<GravityWhileClimbing>().isAttachedL == true && gripAnimationAction.action.ReadValue<float>() > 0.1f)
        {
            Debug.Log("handLlock");
            handAnimator.SetFloat("Trigger", 1f);
            handAnimator.SetFloat("Grip", 1f);
            handAnimator.SetFloat("TouchPadTouch", 1f);
        }
        if(gameObject.tag == "HandR" && _Player.GetComponent<GravityWhileClimbing>().isAttachedR == true && gripAnimationAction.action.ReadValue<float>() > 0.1f)
        {
            Debug.Log("handlock");
            handAnimator.SetFloat("Trigger", 1f);
            handAnimator.SetFloat("Grip", 1f);
            handAnimator.SetFloat("TouchPadTouch", 1f);
        }
        else
        {
            float triggerValue = pinchAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat("Trigger", triggerValue);

            float gripValue = gripAnimationAction.action.ReadValue<float>();
            handAnimator.SetFloat("Grip", gripValue);

            float thumbValue = thumbTouch.action.ReadValue<float>();
            handAnimator.SetFloat("TouchPadTouch", thumbValue);
        }

    }
}
