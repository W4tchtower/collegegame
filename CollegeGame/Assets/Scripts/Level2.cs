using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    [SerializeField] private GameObject Spook1;
    private const float SPOOK1_START_Y = 0.18f;
    private const float SPOOK1_START_X = -0.4f;

    // events
    private bool lightHasTurnedOff;

    protected override void Start()
    {
        base.Start();
        lightHasTurnedOff = false;
    }

    void Update()
    {
        runHallEvent();
    }

    protected override void generateHallway()
    {
        for(int i = 0; i < hallAmount; i++)
        {
            if(i < 1)
            {
                GameObject wall = (GameObject)Instantiate(
                    Wall,
                    new Vector2(i, WALL_HEIGHT),
                    Quaternion.identity
                );
                GameObject entryDoor = (GameObject)Instantiate(
                    EntryDoor,
                    new Vector2(i * EntryDoor.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                entryDoor.GetComponentInChildren<Door>().setLocked(true);
                halls.Add(entryDoor);
            }
            else if(i < 2)
            {
                GameObject hall = (GameObject)Instantiate(
                    Hall,
                    new Vector2(i * Hall.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                GameObject dialogueSpace = (GameObject)Instantiate(
                    DialogueSpace,
                    new Vector2(i * Hall.GetComponent<Renderer>().bounds.size.x, DIALOGUESPACE_HEIGHT),
                    Quaternion.identity
                );
                dialogueSpace.GetComponent<DialogueSpace>().setDialogue("And yet... \nSomething else is here.");
                halls.Add(hall);
            }
            else if(i < 4)
            {
                GameObject hall = (GameObject)Instantiate(
                    Hall,
                    new Vector2(i * Hall.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                halls.Add(hall);
            }
            else
            {
                GameObject exitDoor = (GameObject)Instantiate(
                    ExitDoor,
                    new Vector2(i * ExitDoor.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                exitDoor.GetComponentInChildren<Door>().setLocked(true);
                halls.Add(exitDoor);

                GameObject dialogueSpace = (GameObject)Instantiate(
                    DialogueSpace,
                    new Vector2(i * Hall.GetComponent<Renderer>().bounds.size.x + 3.0f, DIALOGUESPACE_HEIGHT),
                    Quaternion.identity
                );
                dialogueSpace.GetComponent<DialogueSpace>().setDialogue( "(hold \'enter\' to take out lighter)", Color.grey, 0f );

                GameObject wall = (GameObject)Instantiate(
                    Wall,
                    new Vector2((i + 1) * ExitDoor.GetComponent<Renderer>().bounds.size.x, WALL_HEIGHT),
                    Quaternion.identity
                );
            }
        }
    }

    private void runHallEvent()
    {
        // turn lights off when player is a certain length into the hallway
        if(!lightHasTurnedOff && player.transform.position.x > halls[4].transform.position.x + 2.0f)
        {
            foreach(GameObject hall in halls)
            {
                hall.GetComponentInChildren<Lightswitch>().turnOffLightbulb();
            }

            // dim first lightbulb and spawn in spooky guy
            halls[1].GetComponentInChildren<Lightswitch>().dimLightbulb();
            halls[0].GetComponentInChildren<Lightswitch>().breakLightbulb();
            GameObject spook1 = (GameObject)Instantiate(Spook1, new Vector2(halls[1].transform.position.x + SPOOK1_START_X, SPOOK1_START_Y), Quaternion.identity);
            lightHasTurnedOff = true;
        }
        else if (lightHasTurnedOff && player.transform.position.x < halls[1].transform.position.x + 1.0f)
        {
            halls[1].GetComponentInChildren<Lightswitch>().breakLightbulb();
            halls[4].GetComponentInChildren<Door>().setLocked(false);
        }
    }
}
