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

    public void OnDialogue(string[] lines, Transform chatPoint, float nextDelay)
    {
        transform.position = chatPoint.position;
        sentences = new Queue<string>();
        sentences.Clear();
        foreach(var line in lines)
        {
            sentences.Enqueue(line);
        }
        StartCoroutine(DialogueFlow(chatPoint, nextDelay));
    }

    IEnumerator DialogueFlow(Transform chatPoint, float nextDelay)
    {

        while (sentences.Count > 0)
        {
            currentSentence = sentences.Dequeue();
            text.text = currentSentence;
            quad.transform.localScale = new Vector2(text.preferredWidth * 1.3f, text.preferredHeight * 1.3f);

            //transform.position = new Vector2(chatPoint.position.x, chatPoint.position.y + text.preferredHeight / 2);
            yield return new WaitForSeconds(nextDelay);
        }

        StateManager.Instance.Pause();
    }
}
