using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1 : Level
{
    public static int iteration = 0;
    public const int TOTAL_ITERATIONS = 4;

    protected override void Start()
    {
        base.Start();

        iteration++;
    }

    protected override void generateHallway()
    {
        for(int i = 0; i < hallAmount; i++)
        {
            if(i == 0)
            {
                GameObject wall = (GameObject)Instantiate(
                    pf_Wall,
                    new Vector2(i, WALL_HEIGHT),
                    Quaternion.identity
                );
                GameObject entryDoor = (GameObject)Instantiate(
                    pf_EntryDoor,
                    new Vector2(i * pf_EntryDoor.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                entryDoor.GetComponentInChildren<Door>().setLocked(true);
                halls.Add(entryDoor);
            }
            else if (i == 1)
            {
                GameObject hall = (GameObject)Instantiate(
                    pf_Hall,
                    new Vector2(i * pf_Hall.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                halls.Add(hall);
            }
            else if(i < 4)
            {
                GameObject hall = (GameObject)Instantiate(
                    pf_Hall,
                    new Vector2(i * pf_Hall.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                halls.Add(hall);
            }
            else
            {
                GameObject exitDoor = (GameObject)Instantiate(
                    pf_ExitDoor,
                    new Vector2(i * pf_ExitDoor.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                exitDoor.transform.Find("Door").GetComponent<Door>().setLocked(false);

                GameObject wall = (GameObject)Instantiate(
                    pf_Wall,
                    new Vector2((i + 1) * pf_ExitDoor.GetComponent<Renderer>().bounds.size.x, WALL_HEIGHT),
                    Quaternion.identity
                );
                halls.Add(exitDoor);
            }
        }
    }

    protected override void runHallEvent()
    {
        return;
    }
}

/*
As the player walks into the new hall, it should say stuff like:

"A metal hallway sprawls out before you. \nYou feel alone."
and then "alone" turns into "like something's watching you" etc.
*/
