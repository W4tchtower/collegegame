using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    private Light2D lightbulb;

    void Start(){
        lightbulb = GetComponentInChildren<Light2D>();
    }

    public override void interact()
    {
        lightbulb.enabled = !lightbulb.enabled;
    }
}
