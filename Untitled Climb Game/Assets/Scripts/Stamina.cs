using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public GameObject panel;
    public ClimbProvider climbProvider;
    public GravityWhileClimbing handCheck;
    public float maxStamina = 100;
    public float currentStamina;
    public float staminaUsage = 5;
    public float staminaRegain = 15;
    public bool groundCheck;
    public RaycastHit hit;
    public Transform startRay;

    public GameObject playerBody;
    public GameObject hands;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentStamina > 0)
        {
            climbProvider.enabled = true;
            StaminaConsumption();
        }
        else if(currentStamina <= 0)
        {
            climbProvider.enabled = false;
        }
        StaminaRegain();
        GroundCheck();
        StaminaPanel();


    }
    public void StaminaConsumption()
    {
        if (handCheck.isAttached == true)
        {
            currentStamina -= staminaUsage * Time.deltaTime;
            Debug.Log(currentStamina);
        }
    }
    public void StaminaRegain()
    {
        if (!handCheck.isAttached && groundCheck == true)
        {
            currentStamina += staminaRegain * Time.deltaTime;
            if (currentStamina >= maxStamina)
            {
                currentStamina = maxStamina;
            }
        }
    }
    public void GroundCheck()
    {
        if(Physics.Raycast(startRay.position, -transform.up, out hit, 1f))
        {
            if (hit.collider.tag == "Ground")
            {
                groundCheck = true;
                Debug.Log("GroundCheck enabled");
                
            }
            else
            {
                groundCheck = false;
                Debug.Log("GroundCheck disabled");
            }
        }
    }
    public void StaminaPanel()
    {
        panel.GetComponent<Image>().fillAmount = currentStamina / 100;
    }
}
