using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightswitch : Interactable
{
    [SerializeField] private AudioSource flickSound;
    [SerializeField] private AudioSource breakBulbSound;

    private Light2D lightbulb;
    private bool broken;

    void Start(){
        lightbulb = GetComponentInChildren<Light2D>();
        broken = false;
    }

    public override void interact()
    {
        if(lightbulb.enabled || GameObject.FindWithTag("Player").GetComponent<Player>().getLighterActive())
        {
            flickSound.Play();
            Debug.Log("Flick sound played");

            if(!broken)
            {
                lightbulb.enabled = !lightbulb.enabled;
            }
        }
    }

    public void turnOffLightbulb()
    {
        flickSound.Play();
        lightbulb.enabled = false;
    }

    public IEnumerator breakLightbulb()
    {
        lightbulb.intensity *= 5;
        breakBulbSound.Play();
        yield return new WaitForSeconds(0.05f);
        lightbulb.enabled = false;
        broken = true;
    }

    public void dimLightbulb()
    {
        lightbulb.intensity /= 3.5f;
    }
}
