using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    protected bool inRange = false;

    void Update()
    {
        if(Input.GetButtonDown("Interact") && inRange){
            interact();
        }
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player")
            inRange = true;
    }

    void OnTriggerExit2D(Collider2D collider){
        inRange = false;
    }

    // my functions
    public abstract void interact();
}
