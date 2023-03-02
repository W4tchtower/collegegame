using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : Room
{
    void Start()
    {
        Instantiate(Wall, new Vector2(nextPosition - (Floor.GetComponent<Renderer>().bounds.size.x / 2), WALL_SPAWN_HEIGHT), Quaternion.identity);
        
        for(int i = 0; i < 10; i++)
        {
            Instantiate(Ceiling, new Vector2(nextPosition, CEILING_SPAWN_HEIGHT), Quaternion.identity);
            Instantiate(Floor, new Vector2(nextPosition, 0), Quaternion.identity);
            Instantiate(Light1, new Vector2(nextPosition + 0.5f, LIGHT1_SPAWN_HEIGHT), Quaternion.identity);
            Instantiate(Door, new Vector2(nextPosition - 0.5f, DOOR_SPAWN_HEIGHT), Quaternion.identity);
            nextPosition += Floor.GetComponent<Renderer>().bounds.size.x;
        }
    }
}
