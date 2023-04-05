using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    [SerializeField] AudioSource doorOpenSound;
    [SerializeField] AudioSource doorLockSound;

    protected GameObject player;

    private bool locked;
    private bool doorTransporting = false; // makes it so that player can't retransport whilst transporting by rapid-fire hitting space

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public override void interact()
    {
        if(!doorTransporting)
        {
            if(!locked)
            {
                doorOpenSound.Play();
            } else {
                doorLockSound.Play();
            }

        }
    }

    void doorTransport()
    {
        doorTransporting = true;
        StartCoroutine(player.GetComponent<Player>().disableMovement(0.5f));
    }

    void doorReset()
    {
        doorTransporting = true;
        StartCoroutine(player.GetComponent<Player>().disableMovement(0.5f));
    }

    public void setLocked(bool p_locked)
    {
        locked = p_locked;
    }
}
