using UnityEngine;

public class NpcSentence : MonoBehaviour
{
    public string[] sentences;
    public Transform chatTr;
    public GameObject chatBox;
    public float StartDelayTime;
    public float NextLineDelayTime;

    public void TalkNpc()
    {
        Invoke("TalkNpcDelay", StartDelayTime);
    }

    private void TalkNpcDelay()
    {
        chatBox.gameObject.SetActive(true);
        chatBox.GetComponent<ChatSystem>().OnDialogue(sentences, chatTr, NextLineDelayTime);
    }
}
