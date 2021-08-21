
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
            Chapter1Manager.Instance.HaveKey = true;
            _npcSentence.TalkNpc();
        }

        else
        {
            _npcSentence.TalkNpc();
        }
    }
}
