using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    public Queue<string> sentences;
    public string currentSentence;
    public TextMeshPro text;
    public GameObject quad;
    public bool PauseAfterChat = false;

    public void OnDialogue(string[] lines, Transform chatPoint, float nextDelay)
    {
        transform.position = chatPoint.position;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach(var line in lines)
        {
            sentences.Enqueue(line);
        }
        StartCoroutine(DialogueFlow(nextDelay));
    }

    IEnumerator DialogueFlow(float nextDelay)
    {

        while (sentences.Count > 0)
        {
            currentSentence = sentences.Dequeue();
            text.text = currentSentence;
            quad.transform.localScale = new Vector2(text.preferredWidth + 2f, text.preferredHeight + 0.5f);

            yield return new WaitForSeconds(nextDelay);
        }

        this.gameObject.SetActive(false);

        if (PauseAfterChat)
        {
            StateManager.Instance.Pause();
        }
    }
}
