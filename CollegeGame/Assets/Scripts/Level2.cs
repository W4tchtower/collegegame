using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : Level
{
    [SerializeField] private GameObject pf_Spook1;
    GameObject spook1;
    private const float SPOOK1_START_Y = 0.18f;
    private const float SPOOK1_START_X = -0.2f;

    // events
    private bool lightHasTurnedOff;
    private bool spookHasBeenPursued;

    protected override void Start()
    {
        base.Start();

        lightHasTurnedOff = false;
    }

    protected override void generateHallway()
    {
        for(int i = 0; i < hallAmount; i++)
        {
            if(i < 1)
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
            else if(i < 2)
            {
                GameObject hall = (GameObject)Instantiate(
                    pf_Hall,
                    new Vector2(i * pf_Hall.GetComponent<Renderer>().bounds.size.x, HALL_HEIGHT),
                    Quaternion.identity
                );
                halls.Add(hall);

                spook1 = (GameObject)Instantiate(
                    pf_Spook1,
                    new Vector2(i * pf_Hall.GetComponent<Renderer>().bounds.size.x + SPOOK1_START_X, SPOOK1_START_Y),
                    Quaternion.identity
                );
                spook1.GetComponent<SpriteRenderer>().enabled = false;
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
                exitDoor.GetComponentInChildren<Door>().setLocked(true);
                halls.Add(exitDoor);

                GameObject wall = (GameObject)Instantiate(
                    pf_Wall,
                    new Vector2((i + 1) * pf_ExitDoor.GetComponent<Renderer>().bounds.size.x, WALL_HEIGHT),
                    Quaternion.identity
                );
            }
        }
    }

    protected override void runHallEvent()
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
            StartCoroutine(halls[0].GetComponentInChildren<Lightswitch>().breakLightbulb());
            spook1.GetComponent<SpriteRenderer>().enabled = true;
            lightHasTurnedOff = true;
        }

        // light breaks if player approaches spook1
        if (lightHasTurnedOff && !spookHasBeenPursued && player.transform.position.x < halls[1].transform.position.x + 1.0f)
        {
            StartCoroutine(halls[1].GetComponentInChildren<Lightswitch>().breakLightbulb());
            halls[4].GetComponentInChildren<Door>().setLocked(false);
            spook1.GetComponent<SpriteRenderer>().enabled = false;
            spookHasBeenPursued = true;
        }
    }
}
