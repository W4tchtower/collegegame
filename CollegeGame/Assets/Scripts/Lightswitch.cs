using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    private Light2D lightbulb;
    private bool broken;

    void Start(){
        lightbulb = GetComponentInChildren<Light2D>();
        broken = false;
    }

    public override void interact()
    {
        if(!broken)
        {
            if(lightbulb.enabled)
            {
                lightbulb.enabled = false;
            }
            else
            {
                if(GameObject.FindWithTag("Player").GetComponent<Player>().getLighterActive())
                {
                    lightbulb.enabled = true;
                }
            }
        }
    }

    public void turnOffLightbulb()
    {
        lightbulb.enabled = false;
    }

    public void breakLightbulb()
    {
        lightbulb.enabled = false;
        broken = true;
    }

    public void dimLightbulb()
    {
        lightbulb.intensity /= 3.5f;
    }
}
