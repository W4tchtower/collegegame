using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    protected LevelFunctions levelFunctions;
    protected Player playerScript; // this is messy bc the GO is called player

    [SerializeField] protected GameObject Player;
    [SerializeField] protected GameObject OtherDoor;
    [SerializeField] protected bool locked;

    private const float PLAYER_DOOR_DISTANCE = 0.03f; // the distance between the player and the ground if spawned at a door's coordinates.
    private bool doorTransporting = false; // makes it so that player can't retransport whilst transporting by rapid-fire hitting space

    void Start()
    {
        levelFunctions = gameObject.transform.parent.GetComponent<LevelFunctions>();
        playerScript = Player.GetComponent<Player>(); // this gets the player SCRIPT from the player gameobject
    }

    public override void interact()
    {
        if(locked)
        {
            Debug.Log("Locked.");
        }
        else if(!doorTransporting)
        {
            StartCoroutine(doorTransport());
        }
    }

    IEnumerator doorTransport()
    {
        doorTransporting = true;
        playerScript.disableMovement = true;
        levelFunctions.fadeToBlack();
        yield return new WaitForSeconds(0.5f); // fade to black transition time
        Player.transform.position = new Vector2(
            OtherDoor.transform.position.x,
            OtherDoor.transform.position.y - PLAYER_DOOR_DISTANCE
        );
        levelFunctions.fadeFromBlack();
        yield return new WaitForSeconds(0.5f);
        playerScript.disableMovement = false;
        doorTransporting = false;
    }
}
