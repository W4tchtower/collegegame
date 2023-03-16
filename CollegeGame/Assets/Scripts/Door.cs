using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    protected GameObject otherDoor;
    protected WorldManager worldManager;        // darkness transitions
    protected GameObject player;
    private const float PLAYER_DOOR_DISTANCE = 0.02f; // the distance between the player and the ground if spawned at a door's coordinates.
    private bool locked;
    private bool doorTransporting = false; // makes it so that player can't retransport whilst transporting by rapid-fire hitting space

    void Start()
    {
        if(gameObject.tag == "ExitDoor")
        {
            otherDoor = GameObject.FindWithTag("EntryDoor");
        }

        worldManager = GameObject.FindWithTag("UI").GetComponent<WorldManager>();
        player = GameObject.FindWithTag("Player");
    }

    public override void interact()
    {
        if(!doorTransporting && !locked)
        {
            doorTransport();
        }
    }

    void doorTransport()
    {
        doorTransporting = true;
        StartCoroutine(player.GetComponent<Player>().disableMovement(0.5f));
        StartCoroutine(worldManager.nextLevel());
    }

    public void setLocked(bool p_locked)
    {
        locked = p_locked;
    }
}
