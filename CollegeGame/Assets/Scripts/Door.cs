using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] private bool locked;

    public override void interact()
    {
        Debug.Log("Door Opening Attempt");
    }
}
