using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPrep : MonoBehaviour
{
    [SerializeField] private GameObject fakeLight;

    void Start()
    {
        Instantiate(fakeLight, new Vector2(0, 10.0f), Quaternion.identity);
    }
}
