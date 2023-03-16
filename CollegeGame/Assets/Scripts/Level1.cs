using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : Level
{
    public static int iteration = 1;
    public const int TOTAL_ITERATIONS = 4;

    protected override void Start()
    {
        base.Start();
    }

    protected override void generateHallway()
    {
        for(int i = 0; i < hallAmount; i++)
        {
            if(i == 0)
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
                halls.Add(entryDoor);
            }
            else if (i == 2)
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
                dialogueSpace.GetComponent<DialogueSpace>().setDialogue( getDialogue() );
                halls.Add(hall);
                halls.Add(dialogueSpace);
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
                exitDoor.transform.Find("Door").GetComponent<Door>().setLocked(false);

                GameObject wall = (GameObject)Instantiate(
                    Wall,
                    new Vector2((i + 1) * ExitDoor.GetComponent<Renderer>().bounds.size.x, WALL_HEIGHT),
                    Quaternion.identity
                );
                halls.Add(exitDoor);
            }
        }
    }

    string getDialogue()
    {
        switch(iteration)
        {
            case 1:
                return "I'm alone here. In my dream omniscience, I know that there's nothing here but myself and thousands of miles of steel halls around me.";
            case 2:
                return "I've been dreaming now for what could be hours or years. Something about the way I can feel the world shifting uncomfortably around me, struggling to settle.";
            case 3:
                return "Something about how the floor seems to sink beneath my feet, like I'm stepping over dusty, dead piano keys.";
            case 4:
                return "I don't get hungry or thirsty here. I don't get tired here either. Nothing to distract me from roaming these endless halls.";
            case 5:
                return "It's only me here. I can feel my brain twisting through these halls, stirring up dust, watching me run in circles. I've never felt more alone.";
            default:
                return string.Empty;
        }
    }
}
