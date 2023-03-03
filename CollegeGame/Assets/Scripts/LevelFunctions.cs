using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFunctions : MonoBehaviour
{
    private Animator UIanim;

    void Start()
    {
        UIanim = GameObject.Find("Canvas").GetComponent<Animator>();
    }

    // general meta functionality
    public void freezeGame()
    {
        Time.timeScale = 0.0f;
    }

    public void unfreezeGame()
    {
        Time.timeScale = 1.0f;
    }

    public void fadeToBlack()
    {
        UIanim.Play("Canvas_FadeToBlack");
    }

    public void fadeFromBlack()
    {
        UIanim.Play("Canvas_FadeFromBlack");
    }
}
