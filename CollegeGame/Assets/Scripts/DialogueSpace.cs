using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpace : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private string dialogue;
    private Color color;
    private float textSpeed;
    private const float DEFAULT_TEXTSPEED = 0.05f;

    void Start()
    {
        dialogueManager = GameObject.FindWithTag("UI").GetComponent<DialogueManager>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            dialogueManager.sendDialogue(dialogue, color, textSpeed);
            StartCoroutine( disableThis() );
    }

    public IEnumerator disableThis()
    {
        yield return new WaitForSeconds(1.2f);
        Debug.Log("Destroyed!");
        Destroy(this);
    }

    public void setDialogue(string p_dialogue, Color? p_color = null, float p_textSpeed = DEFAULT_TEXTSPEED)
    {
        dialogue = p_dialogue;
        color = p_color ?? Color.white;;
        textSpeed = p_textSpeed;
    }
}
