using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldManager : MonoBehaviour
{
    private Animator UIanim;

    void Start()
    {
        UIanim = this.transform.GetComponentInChildren<Canvas>().GetComponent<Animator>();
    }

    public IEnumerator nextLevel()
    {
        fadeToBlack();
        yield return new WaitForSeconds(0.5f); // fade to black transition time
        if(SceneManager.GetActiveScene().buildIndex == 0 && Level1.iteration < Level1.TOTAL_ITERATIONS)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Level1.iteration++;
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // general meta functionality
    public void pauseGame()
    {
        Time.timeScale = 0.0f;
    }

    public void unpauseGame()
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
