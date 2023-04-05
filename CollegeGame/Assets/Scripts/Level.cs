using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [SerializeField] protected GameObject pf_Player;
    [SerializeField] protected GameObject pf_FakeLight;
    [SerializeField] protected GameObject pf_Hall;
    [SerializeField] protected GameObject pf_EntryDoor;
    [SerializeField] protected GameObject pf_ExitDoor;
    [SerializeField] protected GameObject pf_Wall;

    protected const float HALL_HEIGHT = 0.8f;
    protected const float WALL_HEIGHT = 0.23f;
    protected const float PLAYER_START_X = 0.75f;
    protected const float PLAYER_START_Y = -0.125f;

    protected static List<GameObject> halls;
    protected GameObject player;
    protected int hallAmount = 5; // number of hall segments, not the width or the height

    protected virtual void Start()
    {
        halls = new List<GameObject>();

        // so that the sprite light works. This should never be messed with.
        Instantiate(pf_FakeLight, new Vector2(0, 10.0f), Quaternion.identity);
        player = (GameObject)Instantiate(pf_Player, new Vector2(PLAYER_START_X, PLAYER_START_Y), Quaternion.identity);
        generateHallway();
    }

    protected virtual void Update()
    {
        runHallEvent();
    }

    protected abstract void generateHallway();
    protected abstract void runHallEvent();
}

/* TODO

This is where I'm gonna keep my notes for this stored.

Gotta center the majority of text here.
Gotta '\n' the lines so that the lines when typed don't break into a new line
halfway into a new word.

And now that we've deleted everything, it might be a good idea to have text be
fade-in and not typed out. And if it comes at the beginning of the level, we can
have it so that it's skippable only, not something that lingers as you move. By,
for example, hitting the space bar. 
*/
