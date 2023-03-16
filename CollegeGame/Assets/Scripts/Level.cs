using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [SerializeField] protected GameObject Player;
    [SerializeField] protected GameObject FakeLight;
    [SerializeField] protected GameObject Hall;
    [SerializeField] protected GameObject EntryDoor;
    [SerializeField] protected GameObject ExitDoor;
    [SerializeField] protected GameObject Wall;
    [SerializeField] protected GameObject DialogueSpace;

    protected const float HALL_HEIGHT = 0.8f;
    protected const float WALL_HEIGHT = 0.23f;
    protected const float DIALOGUESPACE_HEIGHT = -0.09f;
    protected const float PLAYER_START_X = 0.75f;
    protected const float PLAYER_START_Y = -0.125f;

    protected static List<GameObject> halls;
    protected GameObject player;
    protected int hallAmount = 5; // number of halls, not the width or the height

    protected virtual void Start()
    {
        halls = new List<GameObject>();

        // so that the sprite light works. This should never be messed with.
        Instantiate(FakeLight, new Vector2(0, 10.0f), Quaternion.identity);
        player = (GameObject)Instantiate(Player, new Vector2(PLAYER_START_X, PLAYER_START_Y), Quaternion.identity);
        generateHallway();
    }

    protected abstract void generateHallway();
}
