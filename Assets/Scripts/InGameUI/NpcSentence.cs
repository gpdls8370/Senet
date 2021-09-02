using UnityEngine;

public class NpcSentence : MonoBehaviour
{
    public string[] sentences;
    public Transform chatTr;
    public GameObject chatBox;
    public float StartDelayTime;
    public float NextLineDelayTime;

    [HideInInspector] public bool isChatting;

    public void TalkNpc()
    {
        if (!isChatting)
        {
            isChatting = true;
            Invoke("TalkNpcDelay", StartDelayTime);
        }
    }

    private void TalkNpcDelay()
    {
        chatBox.gameObject.SetActive(true);
        chatBox.GetComponent<ChatSystem>().OnDialogue(sentences, chatTr, NextLineDelayTime);
    }
}
