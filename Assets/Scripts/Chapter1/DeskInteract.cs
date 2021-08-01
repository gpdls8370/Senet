using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskInteract : InteractObject
{
    public bool isKeyDesk;
    private NpcSentence _npcSentence;

    private void Start()
    {
        _npcSentence = GetComponentInParent<NpcSentence>();
    }

    protected override void DoThis()
    {
        if (isKeyDesk)
        {
            Debug.Log("열쇠책상");
            _npcSentence.TalkNpc();
        }

        else
        {
            Debug.Log("열쇠없는책상");
            _npcSentence.TalkNpc();
        }
    }
}
