using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public const float DEFAULT_TEXTSPEED = 0.03f;
    public const float DEFAULT_TEXTLINGERTIME = 1.5f;

    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = this.transform.GetComponentInChildren<Canvas>().GetComponentInChildren<TMPro.TextMeshProUGUI>();
        clear();
    }

    public void sendDialogue(string p_dialogue, Color p_color, float p_textSpeed)
    {
        StopAllCoroutines();
        clear();
        Debug.Log("Printing: \"" + p_dialogue + "\"");
        StartCoroutine( typeDialogue(p_dialogue, p_color, p_textSpeed) );
    }

    private IEnumerator typeDialogue(string p_dialogue, Color p_color, float p_textSpeed)
    {
        textMesh.color = new Color(p_color.r, p_color.g, p_color.b, 1);

        if(p_textSpeed == 0.0f)
        {
            textMesh.text = p_dialogue;
            yield return new WaitForSeconds(4.0f);
        }
        else
        {
            foreach (char c in p_dialogue.ToCharArray())
            {
                textMesh.text += c;
                yield return new WaitForSeconds(p_textSpeed);
            }
            yield return new WaitForSeconds(1.0f);
        }
        StartCoroutine( fade(DEFAULT_TEXTLINGERTIME) );
    }

    public void clear()
    {
        textMesh.text = string.Empty;
    }

    public IEnumerator fade(float p_time)
    {
        while (textMesh.color.a > 0.0f)
        {
            textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, textMesh.color.a - (Time.deltaTime / p_time));
            yield return null;
        }
    }
}
