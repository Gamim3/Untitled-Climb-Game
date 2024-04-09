using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Stamina : MonoBehaviour
{
    public GameObject panel;
    public GameObject postProsessEffects;
   
    public AudioSource soundSource;
    public GravityWhileClimbing handCheck;
    public UnityEngine.XR.Interaction.Toolkit.ClimbProvider climbprovider;
    public float maxStamina = 100;
    public float currentStamina;
    public float staminaUsage;
    public float staminaUsageHeavy;
    public float staminaUsageLight;
    public float staminaRegain;
    public float staminaRegainOnWall;
    public float distance;
    public float minVolume;
    public float maxVolume;
    public bool groundCheck;
    public RaycastHit hit;
    public Transform startRay;
    public Transform avHand;
    public GameObject playerBody;
    public GameObject handL;
    public GameObject handR;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerBody.transform.position, avHand.transform.position);
        //Debug.Log(distance);
        avHand.position = (handR.transform.position + handL.transform.position) /2;
        if (currentStamina <= 0)
        {
            this.GetComponent<UnityEngine.XR.Interaction.Toolkit.ClimbProvider>().enabled = false;
        }
        else if(currentStamina > 0)
        {
            this.GetComponent<UnityEngine.XR.Interaction.Toolkit.ClimbProvider>().enabled = true;
            StaminaConsumption();
           
        }
        StaminaRegain();
        GroundCheck();
        StaminaPanel();
        SoundsManager();


    }
    public void StaminaConsumption()
    {
        if (handCheck.isAttachedR == true|| handCheck.isAttachedL == true)
        {
            if (playerBody.transform.position.y >= avHand.position.y)
            {
                currentStamina -= staminaUsageHeavy * Time.deltaTime;
            }
            if (playerBody.transform.position.y <= avHand.position.y && distance <= .4f)
            {
                currentStamina -= staminaUsageLight * Time.deltaTime;
            }
            if (playerBody.transform.position.y <= avHand.position.y && distance >= .4f)
            {
                currentStamina += staminaRegainOnWall * Time.deltaTime;
            }
        }
        
    }
    public void StaminaRegain()
    {
        if (!handCheck.isAttachedR && groundCheck == true || !handCheck.isAttachedR && groundCheck == true)
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
                
            }
            else
            {
                groundCheck = false;
            }
        }
    }
    public void StaminaPanel()
    {
        panel.GetComponent<Slider>().value = currentStamina / 100;

        Vignette vignette;
        postProsessEffects.GetComponent<Volume>().profile.TryGet<Vignette>(out vignette);
        if (currentStamina <= 50)
        {

            vignette.intensity.value = 1 - currentStamina / 50;
        }
        else
        {
            vignette.intensity.value = 0f;
        }
        
    }

    public void SoundsManager()
    {
       if(currentStamina <= 50)
       {
        
            soundSource.enabled = true;
            currentStamina = Mathf.Clamp(currentStamina,0,maxStamina);
            float t = currentStamina / maxStamina;
            float volume = Mathf.Lerp(maxVolume,minVolume,t);
            soundSource.volume = volume;
            
            /*
            float maxSpeed = 3f;
            float minSpeed =1;
            float newSpeed =Mathf.Lerp(maxSpeed,minSpeed,t);
            soundSource.pitch = newSpeed;
            soundSource.outputAudioMixerGroup.audioMixer.SetFloat("Pitch", 1f / newSpeed);
            */
       
       }
       else
       {
            soundSource.volume = 0;
            soundSource.enabled = false;
       }

    }
}
