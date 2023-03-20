using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSpace : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private string dialogue;
    private Color color;
    private float textSpeed;

    void Start()
    {
        dialogueManager = GameObject.FindWithTag("UI").GetComponent<DialogueManager>();
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            dialogueManager.sendDialogue(dialogue, color, textSpeed);
            Debug.Log("Destroyed");
            Destroy(this);
        }
    }

    public void setDialogue(string p_dialogue, Color? p_color = null, float p_textSpeed = DialogueManager.DEFAULT_TEXTSPEED)
    {
        dialogue = p_dialogue;
        color = p_color ?? Color.white;;
        textSpeed = p_textSpeed;
    }
}
