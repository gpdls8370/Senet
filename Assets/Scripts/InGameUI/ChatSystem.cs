using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChatSystem : MonoBehaviour
{
    [SerializeField] private Queue<string> sentences;
    [SerializeField] private string currentSentence;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject quad;
    [SerializeField] private bool PauseAfterChat = false;
    [SerializeField] private bool DeadAfterChat = false;
    public bool PopupAfterChat = false;
    [SerializeField] private GameObject Popup;

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
        currentSentence = sentences.Dequeue();
        text.text = currentSentence;
        quad.transform.localScale = new Vector2(text.preferredWidth + 1.5f, text.preferredHeight + 1f);

        yield return new WaitForSeconds(nextDelay);

        if (sentences.Count > 0)
        {
            StartCoroutine(DialogueFlow(nextDelay));
        }
        else
        {
            ChatEnd();
        }
    }

    private void ChatEnd()
    {
        gameObject.SetActive(false);

        if (PauseAfterChat)
        {
            StateManager.Instance.Pause();
        }

        if (DeadAfterChat)
        {
            StateManager.Instance.SetDead();
        }

        if (PopupAfterChat)
        {
            UIManager.Instance.Panel_Enable(Popup);
            PopupAfterChat = false;
        }

        GetComponentInParent<NpcSentence>().isChatting = false;
    }
}
