using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] protected GameObject Player;
    [SerializeField] protected GameObject FakeLight;
    [SerializeField] protected GameObject Floor;
    [SerializeField] protected GameObject Ceiling;
    [SerializeField] protected GameObject Light1;
    [SerializeField] protected GameObject Door;
    [SerializeField] protected GameObject Wall;
    [SerializeField] protected GameObject SideDoor;
    // these are just good heights to spawn stuff in at
    protected const float PLAYER_SPAWN_HEIGHT = 0.528f;
    protected const float DOOR_SPAWN_HEIGHT = 0.58f;
    protected const float CEILING_SPAWN_HEIGHT = 1.86f;
    protected const float LIGHT1_SPAWN_HEIGHT = 1.18f;
    protected const float WALL_SPAWN_HEIGHT = 0.863f;
    protected const float SIDEDOOR_SPAWN_HEIGHT = 0.541f;

    protected float nextPosition = 0.0f; //placeholder for where we are x-pos-wise

    void Start(){
        Instantiate(FakeLight, new Vector2(0, 10), Quaternion.identity);
    }
}
