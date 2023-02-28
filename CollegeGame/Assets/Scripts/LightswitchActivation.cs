using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightswitchActivation : MonoBehaviour
{
    private Light2D lightbulb;
    private bool canSwitch = false;

    void Start(){
        lightbulb = GetComponentInChildren<Light2D>();
    }

    void Update(){
        if(Input.GetButtonDown("Interact") && canSwitch){
            lightbulb.enabled = !lightbulb.enabled;
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        // If this ends up not working later,
        // try verifying via code that it's the *player*
        // that's entering the trigger zone.
        canSwitch = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        canSwitch = false;
    }
}
