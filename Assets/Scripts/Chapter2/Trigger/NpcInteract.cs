using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteract : InteractObject
{
    protected override void DoThis()
    {
        GetComponent<NpcSentence>().TalkNpc();
    }
}
